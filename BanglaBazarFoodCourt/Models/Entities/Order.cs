using System;
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
        public Customer Customer { get; set; }

        [DisplayName("Total Price")]
        public double totalPrice { get; set; }

        [DisplayName("Order Time")]
        public string orderTime { get; set; }

        [DisplayName("Pickup Time")]
        public string pickupTime { get; set; }

        [DisplayName("Date")]
        public DateTime date { get; set; }
    }
}