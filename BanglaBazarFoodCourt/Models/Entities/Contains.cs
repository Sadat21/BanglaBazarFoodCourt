using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.Models.Entities
{
    public class Contains
    {
        [Key]
        [Column(Order=0)]
        [ForeignKey("Order")]
        public int OrderNo { get; set; }
        public Order Order { get; set; }
        [Key]
        [Column(Order=1)]
        [ForeignKey("Food_Item")]
        public int FoodID { get; set; }
        public Food_Item Food_Item { get; set; }
        public int Quantity { get; set; }
    }
}