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
    public class IndexModel : PageModel
    {
        private readonly PorchSwingFarms.Data.FarmContext _context;

        public IndexModel(PorchSwingFarms.Data.FarmContext context)
        {
            _context = context;
        }

        public IList<Subscription> Subscription { get;set; }

        public async Task OnGetAsync()
        {
            Subscription = await _context.Subscriptions.ToListAsync();
        }
    }
}
