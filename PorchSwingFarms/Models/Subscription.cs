using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PorchSwingFarms.Models
{
    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public int Price { get; set; }
        public int Frequency { get; set; }
    }
}
