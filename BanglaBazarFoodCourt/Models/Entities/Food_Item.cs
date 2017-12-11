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

        [Required]
        public string Name { get; set; }

        [Range(0,999)]
        public int Availability { get; set; }

        [Required]
        public string Type { get; set; }

        [StringLength(160)]
        public string Description { get; set; }

        [Range(0,200)]
        [Required]
        public double Price { get; set; }

        [Required]
        public byte [] Picture { get; set; }
    }
}