using SHOP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SHOP.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private ShopEntities db = new ShopEntities();
        public ActionResult Index()
        {
            ViewBag.countProducts = db.Products.Count(x => x.id > 0);
            ViewBag.countOrders = db.Orders.Count(x => x.id > 0);
            ViewBag.countUsers = db.Users.Count(x => x.id > 0);
            ViewBag.countContacts = db.Contacts.Count(x => x.id > 0);

          

            Dictionary<Product, int> TopProduct = new Dictionary<Models.Product, int>();

            foreach (var product in db.Products)
            {
                int count = 0;
                foreach (var order in db.Orders)
                {
                    if (order.ProductId.Equals(product.id))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
TopProduct.Add(product, count);
                }
                
            }
            ViewData["topproduct"] = TopProduct;



            Dictionary<User, int> TopUser = new Dictionary<User, int>();

            foreach (var user in db.Users)
            {
                int count = 0;
                foreach (var order in db.Orders)
                {
                    if (order.UserId.Equals(user.id))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                      TopUser.Add(user, count);
                }
                
            }
            ViewData["topuser"] = TopUser;

            if (Session["username"] != null)
            {

            }
            return View();
        }

        public ActionResult ListUsers()
        {
            return View(db.Users.ToList());
        }

        //Product

        public ActionResult ListProducts()
        {
            return View(db.Products.ToList());
        }

       public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "id", "Name", product.CategoryId);
            return View(product);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct([Bind(Include = "id,Name,Price,Picture,Description,CategoryId,Datetime")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                string path = Path.Combine(Server.MapPath("~/Content/images/products/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

                path = Path.Combine(Server.MapPath("~/Content/images/products/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

                product.Picture = "/Content/images/products/" + file.FileName;


                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("listproducts");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "id", "Name", product.CategoryId);
            return View(product);
        }

  

        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: test/Delete/5
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddProduct()
        {
            ViewData["list"] = db.Categories.ToList();
           
            return View();
        }

        [HttpPost]
 
        public ActionResult AddProduct(FormCollection form, HttpPostedFileBase file)
        {


            Product product = new Product();

           

            if ((Request.Form["catid"] != null && Request.Form["name"] != "" && Request.Form["price"] != "" && Request.Form["price"] != "" && file != null))
            {

                string path = Path.Combine(Server.MapPath("~/Content/images/products/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

                path = Path.Combine(Server.MapPath("~/Content/images/products/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

                product.Picture = "/Content/images/products/" + file.FileName;
                product.Name = Request.Form["name"];
                string narx = (Request.Form["price"]);
                product.Price = decimal.Parse(narx);
                product.Description = Request.Form["description"];
                product.CategoryId = int.Parse(Request.Form["catid"]);
                product.Datetime = DateTime.Now;
                db.Products.Add(product); 
                db.SaveChanges();
                ViewData["list"] = db.Categories.ToList();
                ViewBag.mess = "Новый продукт успешно добавлен в базу данных";
                ViewBag.flag = "1";
        
                return View();
            }
            else
            {
                ViewData["list"] = db.Categories.ToList();
                ViewBag.flag = "0";
                ViewBag.mess = "Заполните форму....";
                return View();
            }
                     

       
           
        }




        public ActionResult ListOrders()
        {
            return View(db.Orders);
        }

        public ActionResult AddUsers()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddUsers(FormCollection form, HttpPostedFileBase file)
        {


            User user = new User();



            if ((Request.Form["login"] != null && Request.Form["phone"] != null && Request.Form["name"] != "" && Request.Form["price"] != "" && Request.Form["password"] != "" && file != null))
            {

                string path = Path.Combine(Server.MapPath("~/Content/images/products/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

                path = Path.Combine(Server.MapPath("~/Content/images/products/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

                user.Picture = "/Content/images/products/" + file.FileName;
                user.Firstname = Request.Form["name"];
                user.Lastname = Request.Form["price"];
   
                user.Address = Request.Form["description"];
                user.PhoneNumber = Request.Form["phone"];
                user.Username = Request.Form["login"];
                user.Password = Request.Form["password"];


                db.Users.Add(user);
                db.SaveChanges();
               
                ViewBag.mess = "Успешно создан новый пользователь";
                ViewBag.flag = "1";

                return View();
            }
            else
            {
               
                ViewBag.flag = "0";
                ViewBag.mess = "Заполните форму....";
                return View();
            }




        }

        public ActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User User = db.Users.Find(id);
            if (User == null)
            {
                return HttpNotFound();
            }
           
            return View(User);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult EditUser([Bind(Include = "id,Firstname,Lastname,Picture,PhoneNumber,Address,Username,Password,Register_date")] User user, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Content/images/products/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

                path = Path.Combine(Server.MapPath("~/Content/images/products/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

                user.Picture = "/Content/images/products/" + file.FileName;


                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(user);
        }

        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedUser(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "id", "Name", order.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Firstname", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder([Bind(Include = "id,ProductId,Order_number,Order_date,Quantity,TotalPrice,UserId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "id", "Name", order.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "id", "Firstname", order.UserId);
            return View(order);
        }






    }
}