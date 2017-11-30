using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models.Entities
{
    public class Employee
    {
        [Key]
        public int SIN { get; set; }

        public string Name { get; set; }

        public double Wage { get; set; }
    }
}