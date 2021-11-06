using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PorchSwingFarms.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public int ZipCode { get; set; }
        public String? ApartmentNum { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String? Email { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
