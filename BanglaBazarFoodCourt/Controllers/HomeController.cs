using BanglaBazarFoodCourt.Models;
using BanglaBazarFoodCourt.ViewModels;
using BanglaBazarFoodCourt.Models.Entities;
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
            var entree = _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item WHERE Type = 'Entree' ");
            var appetizer = _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item WHERE Type = 'Appetizers' ");
            var dessert = _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item WHERE Type = 'Dessert' ");
            var drink = _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item WHERE Type = 'Drink' ");
            var promos = _context.PromoTable.ToList();
            var contain = _context.Contains_Table.ToList();

            OrderViewModel forOrder = new OrderViewModel
            {
                Dessert = dessert,
                Entree = entree,
                Appetizer = appetizer,
                Drink = drink,
                Promo = promos,
                Contain = contain,
                Customers = new Customer(),
                Orders = new Order(),
                OrderQty = 1,
            };

            return View(forOrder);
        }

        
       /** [HttpPost]
        public ActionResult UpdateOrderItem(OrderViewModel order, float orderPrice)
        {
            int temp = ++order.OrderQty;
            order.OrderPrice = orderPrice;
            ModelState.Remove("OrderQty");
            order.OrderQty = temp;
            return View(order);
        }

        public ActionResult AddOrderItem(OrderViewModel model, int id)
        {
            Food_Item temp = _context.Food_ItemTable.Find(id);
            model.OrderPrice = model.OrderQty * temp.Price;
            return View(model.OrderPrice);
        }*/
        
        
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