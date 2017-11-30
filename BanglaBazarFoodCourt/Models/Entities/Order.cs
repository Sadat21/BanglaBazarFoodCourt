using System;
using System.Collections.Generic;
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
        public Customer Customer { get; set; }
        public double totalPrice { get; set; }
        public string orderTime { get; set; }
        public string pickupTime { get; set; }
        public DateTime date { get; set; }
    }
}