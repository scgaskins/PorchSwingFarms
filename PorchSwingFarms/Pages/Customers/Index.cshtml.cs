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

namespace PorchSwingFarms.Pages.Customers
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
        public string AddressSort { get; set; }
        public string CitySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public int? CurrentSize { get; set; }

        public PaginatedList<Customer> Customers { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, int? pageSize)
        {
            CurrentSort = sortOrder;
            CurrentSize = pageSize;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            AddressSort = sortOrder == "Address" ? "address_desc" : "Address";
            CitySort = sortOrder == "City" ? "city_desc" : "City";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Customer> customersIQ = from c in _context.Customers
                                             select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                customersIQ = customersIQ.Where(c => c.FirstName.ToUpper().Contains(searchString.ToUpper())
                || c.LastName.ToUpper().Contains(searchString.ToUpper())
                );
            }

            switch (sortOrder)
            {
                case "name_desc":
                    customersIQ = customersIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Address":
                    customersIQ = customersIQ.OrderBy(s => s.Address);
                    break;
                case "address_desc":
                    customersIQ = customersIQ.OrderByDescending(s => s.Address);
                    break;
                case "City":
                    customersIQ = customersIQ.OrderBy(s => s.City).ThenBy(s => s.LastName);
                    break;
                case "city_desc":
                    customersIQ = customersIQ.OrderBy(s => s.City).ThenBy(s => s.LastName);
                    break;
                default:
                    customersIQ = customersIQ.OrderBy(s => s.LastName);
                    break;
            }
          
            var defaultSize = Configuration.GetValue("PageSize", 10);
            Customers = await PaginatedList<Customer>.CreateAsync(
                customersIQ.AsNoTracking(), pageIndex ?? 1, pageSize ?? defaultSize);
        }
    }
}
