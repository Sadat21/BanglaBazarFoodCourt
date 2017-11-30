using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models.Entities
{
    public class Supervisor
    {
        [Key]
        [ForeignKey("Employee")]
        public int SIN { get; set; }
        public Employee Employee { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}