using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PorchSwingFarms.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public bool DeliveredYN { get; set; }
        public bool PaidForYN { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Subscription Subscription { get; set; }
        public Customer Customer { get; set; }
    }
}
