using BanglaBazarFoodCourt.Models;
using BanglaBazarFoodCourt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanglaBazarFoodCourt.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
//            ViewBag.Message = _context.Database.ExecuteSqlCommand("INSERT INTO Customers(name, contactNo) VALUES ('Sadat', 123)");

            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Menus()
        {

            var entree = _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item WHERE Type = 'Entree' ");
            var appetizer = _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item WHERE Type = 'Appetizers' ");
            var dessert = _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item WHERE Type = 'Dessert' ");
            var drink = _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item WHERE Type = 'Drink' ");

            MenuViewModel toBeSent = new MenuViewModel
            {
                Dessert = dessert,
                Entree = entree,
                Appetizer = appetizer,
                Drink = drink
            };
            return View(toBeSent);
        }

        public ActionResult Specials()
        {
            var entities = _context.PromoTable.ToList();
            return View(entities);
        }
    }
}