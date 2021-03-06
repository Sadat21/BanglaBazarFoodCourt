﻿using BanglaBazarFoodCourt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanglaBazarFoodCourt.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<Food_Item> Entree { get; set; }
        public IEnumerable<Food_Item> Appetizer { get; set; }
        public IEnumerable<Food_Item> Dessert { get; set; }
        public IEnumerable<Food_Item> Drink { get; set; }
    }
}