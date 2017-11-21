using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models
{
    public class Customer
    {
        
        public int id { get; set; }
        public string name { get; set; }
        public string contactNo { get; set; }
    }
}