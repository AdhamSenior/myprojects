using SHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOP.Controllers
{
    public class HomeController : Controller
    {
        private ShopEntities db = new ShopEntities();
        public ActionResult Index()
        {
          
         
            return View();
        }
        [HttpPost]
        public ActionResult Index(string search, string item,FormCollection form)
        {
   
           
            return View();
        }


        public ActionResult Login()
        {
            ViewBag.Message = "Login Page";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string parol)
        {
            
            var result = db.Users.FirstOrDefault(x => x.Username.Equals(login) && x.Password.Equals(parol));
            if (result != null)
            {
                RolesUser role = db.RolesUsers.Single(x => x.UserID == result.id);

                if (role.RoleId == 2)
                {
                    Session["username"] = result.Firstname;
                    Session["userid"] = result.id;
                    return View("index");
                }
                else
                {
                    Session["username"] = result.Firstname;
                    Session["userid"] = result.id;
                    return RedirectToAction("index","admin");
                }
              
            } 
            else
            {
                ViewBag.mess = "ваше имя пользователя или пароль неверны";
               return View();
            }

        
        }


        [HttpPost]
        public ActionResult Search(string search)
        {
            List<Product> result = db.Products.Where(x => x.Name.Equals(search) || x.Description.Equals(search) || x.Price.ToString().Equals(search) || x.Category.Name.Equals(search) || x.Category.Type.Name.Equals(search)).Select(x=>x).ToList();

            if (result.Count == 0)
            {
                Session["result"] = "Продукты не найдены. Введите правильное значение для поиска...";
                return View();
            }
            else {


                Dictionary<Product, int> top = new Dictionary<Models.Product, int>();

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
                    top.Add(product, count);
                }
                ViewData["top"] = top;
                ViewData["products"] = db.Products.ToList();
                return View("shop", result);

            }
        }
        [HttpPost]
        public ActionResult Subscribe(string email)
        {
            Session["subscribe"] = "Вы подписались на новости!!";

            return View();
        }

        public ActionResult unSubscribe()
        {
            Session["subscribe"] = "Вы отменили подписку на новости!!";

            return View();
        }

        [HttpPost]
        public ActionResult unSubscribe(string email)
        {
            Session["subscribe"] = "Вы отменили подписку на новости!!";

            return View();
        }

        public ActionResult WishList()
        {
            ViewBag.Message = "Login Page";

            return View();
        }

        public ActionResult Registered()
        {
            ViewBag.Message = "Registered Page";

            return View();
        }

        [HttpPost]
        public ActionResult Registered(FormCollection form)
        {



            string povtor = Request.Form["povparol"];
            string check = Request.Form["checkbox"];

            if (Request.Form["povparol"].Equals(Request.Form["parol"]) && (Request.Form["checkbox"] != null || Request.Form["checkbox"] != ""))
            {
                User user = new Models.User();
                user.Firstname = Request.Form["name"];
                user.Lastname = Request.Form["lastname"];
                user.PhoneNumber = Request.Form["number"];
                user.Address = Request.Form["address"];
                user.Username = Request.Form["login"];
                user.Password = Request.Form["parol"];
                user.Register_date = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                ViewBag.mess = "Вы успешно зарегистрировались";
                Session["username"] = user.Firstname;
                Session["userid"] = user.id;
                return View("index");
            }
            else {
                ViewBag.mess = "Подтвердить пароль или флажок недействителен";

            }
            return View();
        }

   
        public ActionResult About()
        {
            ViewBag.Message = "About Page";

            return View();
        }

        private static List<Product> cart = new List<Models.Product>();
        public ActionResult Checkout(int ? id)
        {
            Session["sum"] = null;
            if (id != null)
            {
                Product toCart = new Models.Product();
                toCart = db.Products.Find(id);
                cart.Add(toCart);
                Session["sum"] = (double)cart.AsEnumerable().Sum(o => o.Price);
                Session["added"] = toCart.Name+ " добавлен в корзину!!!";
                Session["count"] = cart.Count;

                return View("shop", db.Products.ToList());
            }

           else
            {
                Session["added"] = null;
                if (cart.Count > 0)
                {
                  Session["sum"] = (long)cart.AsEnumerable().Sum(o => o.Price);
                }
           
                if (Session["sum"] == null)
                {
                    Session["sum"] = 0;
                }



             
                return View(cart.ToList());
            }
        }

        public ActionResult DeleteProductFromCheckout(int? id)
        {

            if (id != null)
            {
               

                foreach (Product product in cart.ToList())
                {
                    if (product.id == id)
                    {
                        cart.Remove(product);
                        break;
                    }
                }

                ViewBag.sum = (double)cart.AsEnumerable().Sum(o => o.Price);
            return View("checkout",cart.ToList());
            }

            else
            {
                ViewBag.sum = 0;
                return View("checkout", cart.ToList());
            }
        }

        public ActionResult ConfirmCart(int? idid)
        {

            if (Session["userid"] == null)
            {
                return View("login");
            }
            else if(idid==-2)
            {
                Random rd = new Random(0);
                int id = (int)Session["userid"];

                User user = db.Users.Find(id);
                foreach (var item in cart)
                {
                    db.Orders.Add(new Order()
                    {
                        ProductId = item.id,
                        Quantity = 1,
                        TotalPrice = item.Price,
                        Order_date = DateTime.Now,
                        Order_number = rd.Next(100, 100000),
                        UserId = user.id
                    });
                }
                db.SaveChanges();
                cart.RemoveAll(x => x.id > 0);
                Session["added"] = null;
                Session["sum"] = 0;
                Session["count"] = 0;
                ViewBag.sum = 0;
                ViewBag.confirm = "Мы вышлем вам эти продукты в ближайшее время для вашего адреса. Спасибо за использование нашего сайта!!";
                return View("checkout",cart);
            }

            else
            {
                cart.RemoveAll(x => x.id > 0);
            }
            return View("shop",db.Products.ToList());
          
        }
        public ActionResult Offers()
        {
            ViewBag.Message = "Offers Page";
            return View();
        }

        public ActionResult Product()
        {
            ViewBag.Message = "Product Page";
            return View();
        }
        public ActionResult Logout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["count"] = null;
            Session["added"] = null;
            Session["sum"] = null;
            cart = null;
            return View("login");
        }
        public ActionResult Logout1()
        {
            Session["userid"] = null;
            Session["username"] = null;
           


            return View();
        }
        public ActionResult Logout2()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["count"] = null;
            Session["added"] = null;
            Session["sum"] = null;
            cart = null;
            ViewBag.countProducts = db.Products.Count(); 
            return View("shop",db.Products.ToList());
        }
        public ActionResult Logout3()
        {
            Session["username"] = null;
            Session["count"] = null;
            Session["added"] = null;
            Session["sum"] = null;
            cart = null;
            return View("checkout",cart.ToList());
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page";
            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            Contact contact = new Models.Contact();
            contact.Yourname = Request.Form["name"];
            contact.Yourlogin = Request.Form["login"];
            contact.YourPhoneNumber = Request.Form["phonenumber"];
            contact.State = 1;
            contact.Messages = Request.Form["message"];
            int count = 0;
            int raznisa = contact.Yourlogin.Length;
            raznisa = 10 - raznisa;
            for (int i = 0; i < raznisa; i++)
            {
                contact.Yourlogin += " ";
            }

            foreach (var item in db.Users)
            {
                if (item.Username.Equals(contact.Yourlogin))
                {
                    count++;
                }
            }
            if (count > 0)
            {
                contact.UserID= db.Users.FirstOrDefault(x => x.Username.Equals(contact.Yourlogin)).id;
            }
            else
            {
                contact.UserID = 0;
            }
 
            contact.Date = DateTime.Now;
         
                   
            db.Contacts.Add(contact);
            db.SaveChanges();
            

            ViewBag.afterRegister = "Ваши сообщения успешно отправлены!!";
            return View();
        }
        public ActionResult Shop(int? id)
        {


            Dictionary<Product, int> top = new Dictionary<Models.Product, int>();

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
                top.Add(product, count);
            }


           
           


            Session["added"] = null;
            int []arr = db.Categories.Where(y => y.TypeId == id).Select(x => x.id).ToArray();

            
            List<Product> result = new List<Models.Product>();


            foreach (var item in db.Products)
            {
                if (check(item.CategoryId,arr)) {
                    result.Add(item);
                }
            }

            if (result.Count > 0)
            {
                ViewBag.countProducts = result.Count();
                ViewData["top"] = top;
                return View(result.ToList());

            }

            else {
                ViewData["top"] = top;
                ViewBag.countProducts = db.Products.Count(); return View(db.Products.ToList());
            }
        }
       
        private bool check(int? item, int[] arr)
        {

            foreach (int id in arr)
            {
                if (id == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}