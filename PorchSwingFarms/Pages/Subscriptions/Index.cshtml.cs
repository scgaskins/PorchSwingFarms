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
    }
}
