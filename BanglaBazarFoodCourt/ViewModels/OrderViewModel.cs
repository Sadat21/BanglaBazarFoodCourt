using BanglaBazarFoodCourt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.ViewModels
{
    public class OrderViewModel
    {
        public IEnumerable<Food_Item> Entree { get; set; }
        public IEnumerable<Food_Item> Appetizer { get; set; }
        public IEnumerable<Food_Item> Dessert { get; set; }
        public IEnumerable<Food_Item> Drink { get; set; }
        public IEnumerable<Promo> Promo { get; set; }
        public Models.Customer Customers { get; set; }
        public Models.Order Orders { get; set; }
        public IEnumerable<Contains> Contain { get; set; }
        public int OrderQty { get; set; }
        public double OrderPrice { get; set; }
    }
}