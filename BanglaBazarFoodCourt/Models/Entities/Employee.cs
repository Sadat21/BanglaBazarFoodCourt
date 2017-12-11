using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models.Entities
{
    public class Employee
    {
        [Key]
        public int SIN { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0,200)]
        public double Wage { get; set; }
    }
}