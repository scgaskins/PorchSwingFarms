using PorchSwingFarms.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PorchSwingFarms.Pages.Subscriptions
{
    public class CustomerNamePageModel : PageModel
    {
        public SelectList CustomerNameSL { get; set; }

        public void PopulateCustomersDropDownList(FarmContext _context,
            object selectedCustomer = null)
        {
            var customersQuery = from d in _context.Customers
                                   orderby d.LastName // Sort by name.
                                   select d;

            CustomerNameSL = new SelectList(customersQuery.AsNoTracking(),
                        "CustomerID", "LastName", selectedCustomer);
        }
    }
}
