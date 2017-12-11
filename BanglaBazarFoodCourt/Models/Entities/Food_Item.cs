using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models.Entities
{
    public class Food_Item
    {
        [Key]
        public int FoodID { get; set; }

        public string Name { get; set; }

        public int Availability { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        [Required]
        public byte [] Picture { get; set; }
    }
}