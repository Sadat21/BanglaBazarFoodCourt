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

    [Authorize]
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
            var entitites = _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item");
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

                _context.Database.ExecuteSqlCommand("INSERT INTO Food_Item (Name, Availability, Type, Description, Price, Picture) VALUES ({0}, {1}, {2}, {3}, {4}, {5})", 
                    new object[] {foodItem.Name, foodItem.Availability, foodItem.Type, foodItem.Description, foodItem.Price, foodItem.Picture });


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
            var x= _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item WHERE FoodID = {0}", id);
            Food_Item temp = x.First();
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
                _context.Database.ExecuteSqlCommand("UPDATE Food_Item SET Name = {0}, Availability = {1}, Type = {2}, Description = {3}, Price = {4} WHERE FoodID = {5}",
                    new object[] { temp.Name, temp.Availability, temp.Type, temp.Description, temp.Price, temp.FoodID});
                //_context.Entry(temp).State = EntityState.Modified;
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
            var x = _context.Food_ItemTable.SqlQuery("SELECT * FROM Food_Item WHERE FoodID = {0}", id);
            Food_Item temp = x.First();
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
            _context.Database.ExecuteSqlCommand("DELETE FROM Food_Item WHERE FoodID = {0}", id);
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

        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //_context.Employees.Add(employee);
                _context.Database.ExecuteSqlCommand("INSERT INTO Employees (Name, Wage) VALUES ({0}, {1})",
                    new object[] { employee.Name, employee.Wage });
                _context.SaveChanges();

            }


            return RedirectToAction("Employees");
        }

        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var x = _context.Employees.SqlQuery("SELECT * FROM Employees WHERE SIN = {0}", id);
            Employee temp = x.First();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(Employee temp)
        {
            if (ModelState.IsValid)
            {
                
                _context.Entry(temp).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Employees");
            }
            return View(temp);
        }

        public ActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var x = _context.Employees.SqlQuery("SELECT * FROM Employees WHERE SIN = {0}", id);
            Employee temp = x.First();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployeeConfirmed(int id)
        {
            _context.Database.ExecuteSqlCommand("DELETE FROM Employees WHERE SIN = {0}", id);
            _context.SaveChanges();
            return RedirectToAction("Employees");
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

        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {

                _context.Database.ExecuteSqlCommand("INSERT INTO Customers (name, contactNo) VALUES ({0}, {1})",
                    new object[] { customer.name, customer.contactNo });
                _context.SaveChanges();

            }


            return RedirectToAction("Customers");
        }

        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var x = _context.CustomerTable.SqlQuery("SELECT * FROM Customers WHERE id = {0}", id);
            Customer temp = x.First();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(Customer temp)
        {
            if (ModelState.IsValid)
            {

                _context.Entry(temp).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Customers");
            }
            return View(temp);
        }

        public ActionResult DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var x = _context.CustomerTable.SqlQuery("SELECT * FROM Customers WHERE id = {0}", id);
            Customer temp = x.First();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        [HttpPost, ActionName("DeleteCustomer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomerConfirmed(int id)
        {
            _context.Database.ExecuteSqlCommand("DELETE FROM Customers WHERE id = {0}", id);
            _context.SaveChanges();
            return RedirectToAction("Customers");
        }

        /**
         * Promotions
         * 
         * */
        public ActionResult Promotions()
        {
            var entitites = _context.PromoTable.SqlQuery("SELECT * FROM Promoes");
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
                _context.Database.ExecuteSqlCommand("INSERT INTO Promoes (StartDate, EndDate, Discount, Name, Description) VALUES ({0}, {1}, {2}, {3}, {4})",
                     new object[] { promo.StartDate, promo.EndDate, promo.Discount, promo.Name, promo.Description });
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
            var x = _context.PromoTable.SqlQuery("SELECT * FROM Promoes WHERE PromoID = {0}", id);
            Promo temp = x.First();
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
            var x = _context.PromoTable.SqlQuery("SELECT * FROM Promoes WHERE PromoID = {0}", id);
            Promo temp = x.First();
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
            _context.Database.ExecuteSqlCommand("DELETE FROM Promoes WHERE PromoID = {0}", id);
            _context.SaveChanges();
            return RedirectToAction("Promotions");
        }

        /**
         * Orders
         * */
        public ActionResult Orders()
        {
            var entitites = _context.OrderTable.SqlQuery("SELECT * FROM Orders");
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
                if(order.Customer == null)
                {
                    _context.OrderTable.Add(order);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Database.ExecuteSqlCommand("INSERT INTO Orders (totalPrice, orderTime, pickupTime, date, Customer_id) VALUES ({0}, {1}, {2}, {3}, {4})",
                    new object[] { order.totalPrice, order.orderTime, order.pickupTime, order.date, order.Customer.id });
                    _context.SaveChanges();
                }
                
            }
            return RedirectToAction("Orders");
        }

        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var x = _context.OrderTable.SqlQuery("SELECT * FROM Orders WHERE orderNo = {0}", id);
            Order temp = x.First();
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
            var x = _context.OrderTable.SqlQuery("SELECT * FROM Orders WHERE orderNo = {0}", id);
            Order temp = x.First();
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
            _context.Database.ExecuteSqlCommand("DELETE FROM Orders WHERE orderNo = {0}", id);
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

                var entities = _context.Contains_Table.SqlQuery("SELECT * FROM [Contains] WHERE OrderNo = {0}", new object[] { id });
                return View(entities.ToList());
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

        public ActionResult DeleteContains(int? OrderNo, int? FoodID)
        {
            if (FoodID == null || OrderNo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var x = _context.Contains_Table.SqlQuery("SELECT * FROM [Contains] WHERE FoodID = {0} AND OrderNo = {1}", new object[] { FoodID, OrderNo });
            Contains temp = x.First();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        [HttpPost, ActionName("DeleteContains")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteContainConfirmed(int? FoodID, int? OrderNo)
        {

            _context.Database.ExecuteSqlCommand("DELETE FROM [Contains] WHERE FoodID = {0} AND OrderNo = {1}", new object[] { FoodID, OrderNo });
            _context.SaveChanges();
            return RedirectToAction("Orders");
        }


    }
}