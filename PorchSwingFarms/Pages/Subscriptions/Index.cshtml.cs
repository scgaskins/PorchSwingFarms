using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PorchSwingFarms.Data;
using PorchSwingFarms.Models;


namespace PorchSwingFarms.Pages.Subscriptions
{
    public class IndexModel : PageModel
    {
        private readonly PorchSwingFarms.Data.FarmContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(PorchSwingFarms.Data.FarmContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string EndDateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public int? CurrentSize { get; set; }

        // The number of days in advance orders will be generated
        public int DaysOrdersGenerated = 60;

        public PaginatedList<Subscription> Subscriptions { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, int? pageSize, bool? noPages)
        {
            CurrentSort = sortOrder;
            CurrentSize = pageSize;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            EndDateSort = sortOrder == "EndDate" ? "enddate_desc" : "EndDate";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Subscription> subscriptionsIQ = from c in _context.Subscriptions
                                                       .Include(s => s.Customer)
                                                       select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                subscriptionsIQ = subscriptionsIQ.Where(
                    s => s.Customer.FullName.ToUpper().Contains(searchString.ToUpper())
                );
            }

            switch (sortOrder)
            {
                case "Date":
                    subscriptionsIQ = subscriptionsIQ.OrderBy(s => s.StartDate).ThenBy(s => s.Customer.LastName);
                    break;
                case "date_desc":
                    subscriptionsIQ = subscriptionsIQ.OrderByDescending(s => s.StartDate).ThenBy(s => s.Customer.LastName);
                    break;
                case "EndDate":
                    subscriptionsIQ = subscriptionsIQ.OrderBy(s => s.EndDate).ThenBy(s => s.Customer.LastName);
                    break;
                case "enddate_desc":
                    subscriptionsIQ = subscriptionsIQ.OrderByDescending(s => s.EndDate).ThenBy(s => s.Customer.LastName);
                    break;
                case "name_desc":
                    subscriptionsIQ = subscriptionsIQ.OrderByDescending(s => s.Customer.LastName);
                    break;
                default:
                    subscriptionsIQ = subscriptionsIQ.OrderBy(s => s.Customer.LastName);
                    break;
            }

            if (noPages == true)
            {
                pageSize = subscriptionsIQ.Count();
            }

            var defaultSize = Configuration.GetValue("PageSize", 10);
            Subscriptions = await PaginatedList<Subscription>.CreateAsync(
                subscriptionsIQ.AsNoTracking(), pageIndex ?? 1, pageSize ?? defaultSize);
        }

        // This is called when the Genrate all new orders button is pressed
        // Also called whenever any post request is made
        public async Task<IActionResult> OnPostAsync()
        {
            List<Subscription> subscriptions = await _context.Subscriptions.Include(s => s.Orders).ToListAsync();

            List<Order> newOrders = GenerateAllNewOrders(subscriptions);

            _context.Orders.AddRange(newOrders);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Orders/Index");
        }

        public List<Order> GenerateAllNewOrders(List<Subscription> subscriptions)
        {
            Console.WriteLine(subscriptions.Count);
            
            List<Order> newOrders = new List<Order>();

            foreach (Subscription sub in subscriptions)
            {
                if (sub.IsActive)
                {
                    List<Order> existingOrders = sub.Orders.OrderByDescending(o => o.DeliveryDate).ToList();
                    DateTime? lastOrderDate = existingOrders.Count > 0 ? existingOrders.First().DeliveryDate : null;


                    // If the subscription is one time only and there is already a previous order
                    // Then we don't want to generate any more orders
                    if (sub.Frequency == Subscription.OrderFrequency.OneTime && lastOrderDate != null)
                    {
                        continue;
                    }

                    DateTime currentOrderDate;

                    if (lastOrderDate != null)
                    {
                        currentOrderDate = IncrementOrderDate(lastOrderDate.Value, sub.Frequency);
                    } else
                    {
                        currentOrderDate = sub.StartDate;
                    }

                    // When we stop generating orders
                    DateTime endDate = sub.EndDate != null ? sub.EndDate.Value : DateTime.Now.AddDays(DaysOrdersGenerated);

                    while (currentOrderDate <= endDate)
                    {
                        // Don't generate orders from the past
                        if (currentOrderDate >= DateTime.Now)
                        {
                            Order newOrder = MakeNewOrder(sub, currentOrderDate);
                            newOrders.Add(newOrder);
                        }

                        // only make one order for a one time subscription
                        if (sub.Frequency == Subscription.OrderFrequency.OneTime)
                        {
                            break;
                        }
                        else
                        {
                            currentOrderDate = IncrementOrderDate(currentOrderDate, sub.Frequency);
                        }
                    }
                }
            }
            return newOrders;
        }

        public Order MakeNewOrder(Subscription subscription, DateTime deliveryDate)
        {
            Order newOrder = new Order();
            newOrder.DeliveredYN = false;
            newOrder.PaidForYN = false;
            newOrder.SubscriptionID = subscription.SubscriptionID;
            newOrder.DeliveryDate = deliveryDate;
            newOrder.Subscription = subscription;
            return newOrder;
        }

        public DateTime IncrementOrderDate(DateTime originalDate, Subscription.OrderFrequency frequency)
        {
            if (frequency == Subscription.OrderFrequency.Weekly)
            {
                return originalDate.AddDays(7);
            }
            else if (frequency == Subscription.OrderFrequency.Biweekly)
            {
                return originalDate.AddDays(14);
            }
            else if (frequency == Subscription.OrderFrequency.Monthly)
            {
                return originalDate.AddDays(30);
            }
            else
            {
                return originalDate;
            }
        }
    }
}
