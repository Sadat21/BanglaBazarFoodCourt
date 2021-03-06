﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models.Entities
{
    [DisplayName("Phone Order")]
    public class Phone_Order
    {
        [Key]
        [Column(Order=0)]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Employee")]
        public int SIN { get; set; }
        public Employee Employee { get; set; }

        [DisplayName("Order Time")]
        public DateTime OrderTime { get; set; }

        [DisplayName("Pickup Time")]
        public DateTime PickupTime { get; set; }

        [DisplayName("Picked Up")]
        public Boolean PickedUp { get; set; }


    }
}