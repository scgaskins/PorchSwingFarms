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

namespace PorchSwingFarms.Pages.Subscriptions
{
    public class EditModel : CustomerNamePageModel
    {
        private readonly PorchSwingFarms.Data.FarmContext _context;

        public EditModel(PorchSwingFarms.Data.FarmContext context)
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
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.SubscriptionID == id);

            if (Subscription == null)
            {
                return NotFound();
            }
            PopulateCustomersDropDownList(_context, Subscription.CustomerID);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionToUpdate = await _context.Subscriptions.FindAsync(id);

            if (subscriptionToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Subscription>(
                 subscriptionToUpdate,
                 "subscription",   // Prefix for form value.
                   s => s.SubscriptionID, s => s.Price, s => s.Quantity, s => s.Frequency, s => s.StartDate, s => s.PaymentDetails, s => s.DeliveryIns, s => s.EndDate, s => s.Customer))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateCustomersDropDownList(_context, subscriptionToUpdate.CustomerID);
            return Page();
        }
    }
}