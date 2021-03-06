﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models.Entities
{
    public class Discounts
    {
        [Key]
        [Column(Order=0)]
        [ForeignKey("Promo")]
        public int PromoID { get; set; }
        public virtual Promo Promo { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Food_Item")]
        public int FoodID { get; set; }
        public virtual Food_Item Food_Item { get; set; }

    }
}