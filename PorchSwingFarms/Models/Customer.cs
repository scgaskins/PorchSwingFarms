using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PorchSwingFarms.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public String City { get; set; }
        [Required]
        public int ZipCode { get; set; }
        public String? ApartmentNum { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        public String? Email { get; set; }

        [Display(Name = "Name")]
        public String FullName
        {
            get => LastName + ", " + FirstName;
        }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
