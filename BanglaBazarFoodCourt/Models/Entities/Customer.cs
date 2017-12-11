using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models
{
    public class Customer
    {
        
        public int id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Contact No.")]
        [Phone]
        [Required]
        public string contactNo { get; set; }
    }
}