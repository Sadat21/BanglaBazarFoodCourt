using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models
{
    public class Order
    {
        [Required]
        private int orderNo { get; set; }
        private int customerId { get; set; }
        private double totalPrice { get; set; }
        private string orderTime { get; set; }
        private string pickupTime { get; set; }
        private DateTime date { get; set; }
    }
}