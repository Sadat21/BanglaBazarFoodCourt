using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models.Entities
{
    public class Promo
    {
        [Key]
        public int PromoID { get; set; }

        public string Name { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set;}

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public double Discount { get; set; }

    }
}