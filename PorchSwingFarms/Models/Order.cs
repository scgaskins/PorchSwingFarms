using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PorchSwingFarms.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public bool DeliveryYN { get; set; }
        public bool PaidForYN { get; set; }
        public String DeliveryIns { get; set; }
        public DateTime StartDate { get; set; }
        public int SubscriptionYN { get; set; }
        public String PaymentDetails { get; set; }
        public Subscription Subscription { get; set; }
        public Customer Customer { get; set; }
    }
}
