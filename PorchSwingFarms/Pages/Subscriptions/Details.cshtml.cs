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
    public class DetailsModel : PageModel
    {
        private readonly PorchSwingFarms.Data.FarmContext _context;

        public DetailsModel(PorchSwingFarms.Data.FarmContext context)
        {
            _context = context;
        }

        public Subscription Subscription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subscription = await _context.Subscriptions.FirstOrDefaultAsync(m => m.SubscriptionID == id);

            if (Subscription == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
