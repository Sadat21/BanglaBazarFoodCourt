using BanglaBazarFoodCourt.Models;
using BanglaBazarFoodCourt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BanglaBazarFoodCourt.Controllers
{
    /**
     * These are the administration web pages
     * 
     *
     * */

    //[Authorize]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        /**
         * Food Items
         * */
        public ActionResult FoodItems()
        {
            var entitites = _context.Food_ItemTable.ToList();
            return View(entitites);
        }

        public ActionResult CreateFoodItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveFoodItem(Food_Item foodItem, HttpPostedFileBase ImageFile)
        {
            
            using (var ms = new MemoryStream())
            {
                ImageFile.InputStream.CopyTo(ms);
                foodItem.Picture = ms.ToArray();
            }

            _context.Food_ItemTable.Add(foodItem);
            _context.SaveChanges();
            return RedirectToAction("FoodItems");
        }

        public ActionResult EditFoodItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Item temp = _context.Food_ItemTable.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFoodItem(Food_Item temp)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(temp).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("FoodItems");
            }
            return View(temp);
        }

        public ActionResult DeleteFoodItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Item temp = _context.Food_ItemTable.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        [HttpPost, ActionName("DeleteFoodItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFoodItemConfirmed(int id)
        {
            Food_Item temp = _context.Food_ItemTable.Find(id);
            _context.Food_ItemTable.Remove(temp);
            _context.SaveChanges();
            return RedirectToAction("FoodItems");
        }

        public ActionResult GetImage(int i)
        {
            byte[] bytes = _context.Food_ItemTable.Find(i).Picture; //Get the image from your database
            return File(bytes, "image/png"); //or "image/jpeg", depending on the format
        }




        /**
         * Employees
         * */
        public ActionResult Employees()
        {
            var entitites = _context.Employees.ToList();
            return View(entitites);
        }

        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee temp = _context.Employees.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        /**
         * Supervisors
         * */
        public ActionResult Supervisors()
        {
            var entitites = _context.SupervisorTable.ToList();
            return View(entitites);
        }

        public ActionResult EditSupervisor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supervisor temp = _context.SupervisorTable.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        /**
         * Customers
         * */
        public ActionResult Customers()
        {
            var entitites = _context.CustomerTable.ToList();
            return View(entitites);
        }

        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _context.CustomerTable.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        /**
         * Promotions
         * //TODO: UPDATE ALL VIEWS SINCE I ADDED NAME
         * */
        public ActionResult Promotions()
        {
            var entitites = _context.PromoTable.ToList();
            return View(entitites);
        }

        public ActionResult CreatePromotion()
        {
            return View();
        }

        

        public ActionResult EditPromotion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promo temp = _context.PromoTable.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        /**
         * Orders
         * */
        public ActionResult Orders()
        {
            var entitites = _context.OrderTable.ToList();
            return View(entitites);
        }

        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order temp = _context.OrderTable.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        /**
         * Phone Orders
         * */
        public ActionResult Phone_Order()
        {
            var entitites = _context.Phone_OrderTable.ToList();
            return View(entitites);
        }

        public ActionResult EditPhone_Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone_Order temp = _context.Phone_OrderTable.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        /**
         * Discounts
         * */
        public ActionResult Discount(int? id)
        {
            
            if (id == null)
            {
                var entitites = _context.DiscountTable.ToList();
                return View(entitites);
            }
            else
            {

                var entities = _context.DiscountTable.SqlQuery("SELECT * FROM Discounts WHERE PromoID = {0}", new object[] { id });
                return View(entities.ToList());
            }
            
        }

        public ActionResult CreateDiscount(int? id)
        {
            
            return View();
        }

       





    }
}