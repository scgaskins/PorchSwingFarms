using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PorchSwingFarms.Models
{
    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Frequency { get; set; }
        public String DeliveryIns { get; set; }
        public String PaymentDetails { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Customer Customer { get; set; }
    }
}
