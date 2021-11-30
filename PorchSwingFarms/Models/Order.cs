using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PorchSwingFarms.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Required]
        [Display(Name = "Delivered")]
        public bool DeliveredYN { get; set; }
        [Required]
        [Display(Name = "Payed For")]
        public bool PaidForYN { get; set; }
        [Required]
        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public Subscription Subscription { get; set; }
    }
}
