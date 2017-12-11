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
            try
            {
                using (var ms = new MemoryStream())
                {
                    ImageFile.InputStream.CopyTo(ms);
                    foodItem.Picture = ms.ToArray();
                }

                _context.Food_ItemTable.Add(foodItem);
                _context.SaveChanges();
            }
            catch
            {

            }
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
         * 
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

        [HttpPost]
        public ActionResult SavePromo(Promo promo)
        {
            if (ModelState.IsValid)
            {
                _context.PromoTable.Add(promo);
                _context.SaveChanges();
                
            }


            return RedirectToAction("Promotions");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPromotion(Promo promo)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(promo).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Promotions");
            }
            return View(promo);
            
        }

        public ActionResult DeletePromotion(int? id)
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

        [HttpPost, ActionName("DeletePromotion")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePromoConfirmed(int id)
        {
            Promo temp = _context.PromoTable.Find(id);
            _context.PromoTable.Remove(temp);
            _context.SaveChanges();
            return RedirectToAction("Promotions");
        }

        /**
         * Orders
         * */
        public ActionResult Orders()
        {
            var entitites = _context.OrderTable.ToList();
            return View(entitites);
        }

        public ActionResult CreateOrder()
        {
            return View();
        }

        public ActionResult SaveOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.OrderTable.Add(order);
                _context.SaveChanges();
            }
            return RedirectToAction("Orders");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder(Order temp)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(temp).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Orders");
            }
            return View(temp);
        }

        public ActionResult DeleteOrder(int? id)
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

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderConfirmed(int id)
        {
            Order temp = _context.OrderTable.Find(id);
            _context.OrderTable.Remove(temp);
            _context.SaveChanges();
            return RedirectToAction("Orders");
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
            ViewBag.PromoID = _context.PromoTable.SqlQuery("SELECT * FROM Promoes WHERE PromoID = {0}", id);

            ViewBag.FoodID = _context.Food_ItemTable.ToList();
            return View();
        }

        public ActionResult SaveDiscount(Discounts discount)
        {
            if (ModelState.IsValid)
            {
                _context.DiscountTable.Add(discount);
                _context.SaveChanges();
            }

            return RedirectToAction("Promotions");
        }

        public ActionResult DeleteDiscount(int? FoodID, int? PromoID)
        {
            if (FoodID == null || PromoID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var x = _context.DiscountTable.SqlQuery("SELECT * FROM Discounts WHERE FoodID = {0} AND PromoID = {1}", new object[] { FoodID, PromoID});
            Discounts temp = x.First();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        [HttpPost, ActionName("DeleteDiscount")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDiscountConfirmed(int? FoodID, int? PromoID)
        {
            var x = _context.DiscountTable.SqlQuery("SELECT * FROM Discounts WHERE FoodID = {0} AND PromoID = {1}", new object[] { FoodID, PromoID });
            Discounts temp = x.First();
            _context.DiscountTable.Remove(temp);
            _context.SaveChanges();
            return RedirectToAction("Discount");
        }




        /*
         * Contains Tables
         * 
         * */
        public ActionResult Contains(int? id)
        {

            if (id == null)
            {
                var entitites = _context.Contains_Table.ToList();
                return View(entitites);
            }
            else
            {
                ViewBag.entities = _context.Contains_Table.SqlQuery("SELECT * FROM Contains WHERE OrderNo = {0}", id);
                
                return View();
            }
            
        }

        public ActionResult CreateContains(int? id)
        {
            ViewBag.OrderNo = _context.OrderTable.SqlQuery("SELECT * FROM Orders WHERE orderNo = {0}", id);

            ViewBag.Food = _context.Food_ItemTable.ToList();

            return View();
            
        }

        public ActionResult SaveContains(Contains contains)
        {
            if (ModelState.IsValid)
            {
                _context.Contains_Table.Add(contains);
                _context.SaveChanges();
            }

            return RedirectToAction("Orders");
        }









    }
}