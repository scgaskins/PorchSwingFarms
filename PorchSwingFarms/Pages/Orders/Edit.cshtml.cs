using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PorchSwingFarms.Data;
using PorchSwingFarms.Models;

namespace PorchSwingFarms.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly PorchSwingFarms.Data.FarmContext _context;

        public EditModel(PorchSwingFarms.Data.FarmContext context)
        {
            _context = context;
        }

        [BindProperty]
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

            Console.WriteLine(Order.DeliveryDate);
            Console.WriteLine(Order.SubscriptionID);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order orderToUpdate = await _context.Orders.FindAsync(id);

            if (orderToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Order>(
                 orderToUpdate,
                 "order",   // Prefix for form value.
                   o => o.DeliveryDate, o => o.DeliveredYN, o => o.PaidForYN))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
