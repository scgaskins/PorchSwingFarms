using PorchSwingFarms.Models;
using PorchSwingFarms.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;

namespace PorchSwingFarms.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public ActionResult OnPostUpload(FileUpload fileUpload) {
            foreach (var file in fileUpload.FormFiles)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read()) { 
                        
                    }
                }
            }
            return Page();
        }

        //file Upload Class
        public class FileUpload
        {
            [Required]
            [Display(Name = "File")]
            public List<IFormFile> FormFiles { get; set; } // convert to list
            public string SuccessMessage { get; set; }
        }
    }

}
