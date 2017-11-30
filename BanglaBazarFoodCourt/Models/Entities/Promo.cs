using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models.Entities
{
    public class Promo
    {
        [Key]
        public int PromoID { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set; }
        public double Discount { get; set; }

    }
}