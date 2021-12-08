using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PorchSwingFarms.Models
{
    public class Subscription
    {
        public enum OrderFrequency
        {
            Weekly, Biweekly, Monthly, OneTime
        };

        public int SubscriptionID { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public OrderFrequency Frequency { get; set; }
        [Display(Name = "Delivery Instructions")]
        public String DeliveryIns { get; set; }
        [Display(Name = "Payment Details")]
        public String PaymentDetails { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(NullDisplayText = "Until Canceled", DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        
        public Customer Customer { get; set; }
        [Required]
        public int CustomerID { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
