using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PorchSwingFarms.Data;
using PorchSwingFarms.Models;

namespace PorchSwingFarms.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly PorchSwingFarms.Data.FarmContext _context;

        public IndexModel(PorchSwingFarms.Data.FarmContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
