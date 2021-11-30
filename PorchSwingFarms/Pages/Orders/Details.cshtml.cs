using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PorchSwingFarms.Data;
using PorchSwingFarms.Models;

namespace PorchSwingFarms.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly PorchSwingFarms.Data.FarmContext _context;

        public DetailsModel(PorchSwingFarms.Data.FarmContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.Subscription)
                .ThenInclude(s => s.Customer)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
