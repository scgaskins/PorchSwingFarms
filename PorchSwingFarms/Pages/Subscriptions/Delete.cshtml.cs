using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PorchSwingFarms.Data;
using PorchSwingFarms.Models;

namespace PorchSwingFarms.Pages.Subscriptions
{
    public class DeleteModel : PageModel
    {
        private readonly PorchSwingFarms.Data.FarmContext _context;

        public DeleteModel(PorchSwingFarms.Data.FarmContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subscription Subscription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subscription = await _context.Subscriptions
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.SubscriptionID == id);

            if (Subscription == null)
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

            Subscription = await _context.Subscriptions.FindAsync(id);

            if (Subscription != null)
            {
                _context.Subscriptions.Remove(Subscription);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
