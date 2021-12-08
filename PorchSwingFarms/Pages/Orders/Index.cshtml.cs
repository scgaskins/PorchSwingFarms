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

namespace PorchSwingFarms.Pages.Orders
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
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public int? CurrentSize { get; set; }

        public PaginatedList<Order> Orders { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, int? pageSize, bool? noPages)
        {
            CurrentSort = sortOrder;
            CurrentSize = pageSize;
            DateSort = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            NameSort = sortOrder == "Name" ? "name_desc" : "Name";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Order> ordersIQ = from o in _context.Orders
                                         .Include(o => o.Subscription)
                                         .ThenInclude(s => s.Customer)
                                               select o;

            if (!String.IsNullOrEmpty(searchString))
            {
                ordersIQ = ordersIQ.Where(o => o.Subscription.Customer.FirstName.ToUpper().Contains(searchString.ToUpper())
                || o.Subscription.Customer.LastName.ToUpper().Contains(searchString.ToUpper())
                );
            }

            switch (sortOrder)
            {
                case "Name":
                    ordersIQ = ordersIQ
                        .OrderBy(o => o.Subscription.Customer.LastName)
                        .ThenBy(o => o.DeliveryDate);
                    break;
                case "name_desc":
                    ordersIQ = ordersIQ
                        .OrderByDescending(o => o.Subscription.Customer.LastName)
                        .ThenBy(o => o.DeliveryDate);
                    break;
                case "date_desc":
                    ordersIQ = ordersIQ
                        .OrderByDescending(o => o.DeliveryDate)
                        .ThenBy(o => o.Subscription.Customer.LastName);
                    break;
                default:
                    ordersIQ = ordersIQ
                        .OrderBy(o => o.DeliveryDate)
                        .ThenBy(o => o.Subscription.Customer.LastName);
                    break;
            }

            if (noPages == true)
            {
                pageSize = ordersIQ.Count();
            }

            var defaultSize = Configuration.GetValue("PageSize", 10);
            Orders = await PaginatedList<Order>.CreateAsync(
                ordersIQ.AsNoTracking(), pageIndex ?? 1, pageSize ?? defaultSize);
        }
    }
}
