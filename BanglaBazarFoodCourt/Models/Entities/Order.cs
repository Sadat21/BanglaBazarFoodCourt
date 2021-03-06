﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models
{
    public class Order
    {
        [Key]
        public int orderNo { get; set; }
        public virtual Customer Customer { get; set; }

        [DisplayName("Total Price")]
        [Range(0,100)]
        public double totalPrice { get; set; }

        [DisplayName("Order Time")]
        [StringLength(5)]
        public string orderTime { get; set; }

        [DisplayName("Pickup Time")]
        [StringLength(5)]
        public string pickupTime { get; set; }

        [DisplayName("Date")]
        [Required]
        public DateTime date { get; set; }
    }
}