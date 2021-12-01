using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PorchSwingFarms.Data;
using PorchSwingFarms.Models;

namespace PorchSwingFarms.Pages.Subscriptions
{
    public class CreateModel : CustomerNamePageModel
    {
        private readonly PorchSwingFarms.Data.FarmContext _context;

        public CreateModel(PorchSwingFarms.Data.FarmContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCustomersDropDownList(_context);

            return Page();
        }

        [BindProperty]
        public Subscription Subscription { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptySubscription = new Subscription();

            if (await TryUpdateModelAsync<Subscription>(
                 emptySubscription,
                 "course",   // Prefix for form value.
                 s => s.SubscriptionID, s => s.Price, s => s.Quantity, s => s.Frequency, s => s.StartDate, s => s.PaymentDetails, s => s.DeliveryIns, s=> s.EndDate, s=> s.Customer ))
            {
                _context.Subscriptions.Add(emptySubscription);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateCustomersDropDownList(_context, emptySubscription.CustomerID);
            return Page();
        }
    }
}
