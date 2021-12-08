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

        public async Task<IActionResult> OnPostAsync()
        {
            List<Subscription> subscriptions = await _context.Subscriptions.Include(s => s.Orders).ToListAsync();
            List<Order> newOrders = new List<Order>();

            foreach (Subscription sub in subscriptions)
            {
                if (sub.IsActive)
                {
                    List<Order> existingOrders = sub.Orders.OrderByDescending(o => o.DeliveryDate).ToList();
                    DateTime? lastOrderDate = existingOrders.Count > 0 ? existingOrders.First().DeliveryDate : null;
                    DateTime startDate = lastOrderDate == null ? sub.StartDate : lastOrderDate.Value;

                    DateTime currentOrderDate;
                    if (sub.Frequency == Subscription.OrderFrequency.Weekly)
                    {
                        currentOrderDate = startDate.AddDays(7);
                    }
                    else if (sub.Frequency == Subscription.OrderFrequency.Biweekly)
                    {
                        currentOrderDate = startDate.AddDays(14);
                    }
                    else if (sub.Frequency == Subscription.OrderFrequency.Monthly)
                    {
                        currentOrderDate = startDate.AddDays(30);
                    } else if (sub.Frequency == Subscription.OrderFrequency.OneTime && lastOrderDate == null)
                    {
                        currentOrderDate = startDate;
                    } 
                    else
                    {
                        continue;
                    }


                    while ((sub.EndDate != null && currentOrderDate <= sub.EndDate) && currentOrderDate <= DateTime.Now.AddDays(60))
                    {
                        Order newOrder = new Order();
                        newOrder.DeliveredYN = false;
                        newOrder.PaidForYN = false;
                        newOrder.SubscriptionID = sub.SubscriptionID;
                        newOrder.DeliveryDate = currentOrderDate;
                        newOrder.Subscription = sub;
                        newOrders.Add(newOrder);

                        if (sub.Frequency == Subscription.OrderFrequency.Weekly) {
                            currentOrderDate = currentOrderDate.AddDays(7);
                        } else if (sub.Frequency == Subscription.OrderFrequency.Biweekly)
                        {
                            currentOrderDate = currentOrderDate.AddDays(14);
                        } else if (sub.Frequency == Subscription.OrderFrequency.Monthly)
                        {
                            currentOrderDate = currentOrderDate.AddDays(30);
                        } else
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(newOrders.Count);

            _context.Orders.AddRange(newOrders);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
