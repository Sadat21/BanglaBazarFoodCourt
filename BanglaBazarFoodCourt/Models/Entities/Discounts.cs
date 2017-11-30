using System;
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
        [ForeignKey("Promo")]
        public int PromoID { get; set; }
        public Promo Promo { get; set; }

    }
}