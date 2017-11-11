using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models
{
    public class Order
    {
        private int orderNo { get; set; }
        private int customerId { get; set; }
        private double totalPrice { get; set; }
        private DateTime orderTime { get; set; }
        private DateTime pickupTime { get; set; }
        private DateTime date { get; set; }
    }
}