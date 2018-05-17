using MobilBor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using MobilBor.Models.Class;

namespace MobilBor.Controllers
{
    public class HomeController : Controller
    {
        mobilborEntities db = new mobilborEntities();

        public ActionResult Index()
        {
            Session["Lang"] = 2;

            foreach (var items in db.Adses)
            {
                if (items.Date.Value.AddMonths(1).CompareTo(DateTime.Now) < 0)
                {
                    items.Sales = 3;
                }
                db.Entry(items);
            }

            db.SaveChanges();

            return View(db.Adses.Where(x=>x.Sales==2));
        }
       
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs()
        {
            Contact c = new Contact();
            c.Name = Convert.ToString(Request.Form["name"]);
            c.Phone = Convert.ToString(Request.Form["phone"]);
            c.Email = Convert.ToString(Request.Form["email"]);
            c.Message = Convert.ToString(Request.Form["message"]);

            db.Contact.Add(c);
            db.SaveChanges();
            return RedirectToAction("Contact","home");
        }

        public ActionResult AddHome()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");
            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            
            Session["Lang"] = 1;
            ViewBag.Id = Session["User"].ToString();
            int id = Int32.Parse(ViewBag.Id);
            
            int count=0;
            Users u = db.Users.FirstOrDefault(x=>x.ID==id);
            ViewBag.Usertype = u.UserType;

            if (u.UserType == 3)
            { 
             count  = db.Adses.Where(x => x.User_Id == id).Count();
            }

            if (count >= 2)
            {
                return RedirectToAction("about", "home");
            }

            Adses ads = new Adses();
            return View();
        }
        [HttpPost]
        public ActionResult AddHome(Adses ads, HttpPostedFileBase[] Images)
        {
            string s = "";
            int count = 0;

            ViewBag.Id = Session["User"].ToString();
            ads.Property_Id = 1;
            ads.Sales = 4;
            ads.Assignment_Id = 0;
            ads.About_Mistake = "0";

            if (ads.Contacts_Id == null)
            {
                ads.Contacts_Id = 2;
            }

            if (ads.LivePlace == null)
            {
                ads.LivePlace = Convert.ToString(0);
            }

            if (ads.Metro_Id == null)
            {
                ads.Metro_Id = 0;
            }

            if (ads.Top_Ads == null)
            {
                ads.Top_Ads = 2;
            }

            ads.Date = DateTime.Now;
            ads.User_Id =Int32.Parse(ViewBag.Id);
            ads.Accept_Rejection = 0;

            db.Adses.Add(ads);
            db.SaveChanges();

               //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in Images)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        // 8 ta rasm oladi
                        if (count > 8) { break; }
                        count++;            
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + ads.ID + "-" + InputFileName);
                        s += Convert.ToString(ads.ID) + "-" + InputFileName + ",";

                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = Images.Count().ToString() + " files uploaded successfully.";
                    }
                else { s = "0"; break; }
            }
            
            ads.Images = s;
            db.Entry(ads);
            db.SaveChanges();

            return RedirectToAction("PersonalCabinet", "Home");
        }

        [HttpPost]
        public ActionResult AddHomeAdmin(Adses ads, HttpPostedFileBase[] Images)
        {
            string s = "";
            int count = 0;

            ViewBag.Id = Session["User"].ToString();
            ads.Property_Id = 1;
            ads.Sales = 2;
            ads.Assignment_Id = 0;
            ads.About_Mistake = "0";

            if (ads.Contacts_Id == null)
            {
                ads.Contacts_Id = 2;
            }

            if (ads.LivePlace == null)
            {
                ads.LivePlace = Convert.ToString(0);
            }

            if (ads.Metro_Id == null)
            {
                ads.Metro_Id = 0;
            }

            if (ads.Top_Ads == null)
            {
                ads.Top_Ads = 2;
            }
            if (ads.Price_Real == null)
            {
                ads.Price_Real = 0;
            }

            ads.Date = DateTime.Now;
            ads.User_Id = Int32.Parse(ViewBag.Id);
            ads.Accept_Rejection = 1;

            db.Adses.Add(ads);
            db.SaveChanges();

            //iterating through multiple file collection   
            foreach (HttpPostedFileBase file in Images)
            {
                //Checking file is available to save.  
                if (file != null)
                {
                    // 8 ta rasm oladi
                    if (count > 8) { break; }
                    count++;
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + ads.ID + "-" + InputFileName);
                    s += Convert.ToString(ads.ID) + "-" + InputFileName + ",";

                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    ViewBag.UploadStatus = Images.Count().ToString() + " files uploaded successfully.";
                }
                else { s = "0"; break; }
            }

            ads.Images = s;
            db.Entry(ads);
            db.SaveChanges();

            return RedirectToAction("PersonalCabinet", "Home");
        }
        public ActionResult AddHomeSecond()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");
            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            Session["Lang"] = 1;
            ViewBag.Id = Session["User"].ToString();
            int id = Int32.Parse(ViewBag.Id);


            int count = 0;
            Users u = db.Users.FirstOrDefault(x => x.ID == id);
            ViewBag.Usertype = u.UserType;
            if (u.UserType == 3)
            {
                count = db.Adses.Where(x => x.User_Id == id).Count();
            }

            if (count >= 2)
            {
                return RedirectToAction("about", "home");
            }

            Adses ads = new Adses();
            return View();
        }
        [HttpPost]
        public ActionResult AddHomeSecond(Adses ads, HttpPostedFileBase[] Images)
        {
            string s = "";
            ViewBag.Id = Session["User"].ToString();

            ads.Property_Id = 2;
            ads.Sales = 4;
            ads.Build_Id = 0;
            ads.State_Id = 0;
            ads.Classification_Id = 0;
            ads.CountRooms = 0;
            ads.SquarePlace = 0;
            ads.LivePlace = Convert.ToString(0);
            ads.Floor = 0;
            ads.All_Floor = 0;
            ads.Accept_Rejection = 0;
            ads.About_Mistake = "0";


            if (ads.Metro_Id == null)
            {
                ads.Metro_Id = 0;
            }

            if (ads.Contacts_Id == null)
            {
                ads.Contacts_Id = 2;
            }
            if (ads.Top_Ads == null)
            {
                ads.Top_Ads = 2;
            }
            if (ads.Price_Real == null)
            {
                ads.Price_Real = 0;
            }
            ads.Date = DateTime.Now;

            ads.User_Id = Int32.Parse(ViewBag.Id);

            db.Adses.Add(ads);
            db.SaveChanges();

            int count = 0;

            foreach (HttpPostedFileBase file in Images)
            {
                if (count > 8) { break; }
                count++;
                //Checking file is available to save.  
                if (file != null)
                {
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + ads.ID + "-" + InputFileName);
                    s += Convert.ToString(ads.ID) + "-" + InputFileName + ",";

                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    ViewBag.UploadStatus = Images.Count().ToString() + " files uploaded successfully.";
                }
                else { s = "0"; break; }

            }

            ads.Images = s;
            db.Entry(ads);
            db.SaveChanges();

            return RedirectToAction("PersonalCabinet", "Home");
        }

        [HttpPost]
        public ActionResult AddHomeSecondAdmin(Adses ads, HttpPostedFileBase[] Images)
        {
            string s = "";
            ViewBag.Id = Session["User"].ToString();

            ads.Property_Id = 2;
            ads.Sales = 2;
            ads.Build_Id = 0;
            ads.State_Id = 0;
            ads.Classification_Id = 0;
            ads.CountRooms = 0;
            ads.SquarePlace = 0;
            ads.LivePlace = Convert.ToString(0);
            ads.Floor = 0;
            ads.All_Floor = 0;
            ads.Accept_Rejection = 0;
            ads.About_Mistake = "0";


            if (ads.Metro_Id == null)
            {
                ads.Metro_Id = 0;
            }

            if (ads.Contacts_Id == null)
            {
                ads.Contacts_Id = 2;
            }
            if (ads.Top_Ads == null)
            {
                ads.Top_Ads = 2;
            }
            ads.Date = DateTime.Now;

            ads.User_Id = Int32.Parse(ViewBag.Id);

            db.Adses.Add(ads);
            db.SaveChanges();

            int count = 0;

            foreach (HttpPostedFileBase file in Images)
            {
                if (count > 8) { break; }
                count++;
                //Checking file is available to save.  
                if (file != null)
                {
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + ads.ID + "-" + InputFileName);
                    s += Convert.ToString(ads.ID) + "-" + InputFileName + ",";

                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    ViewBag.UploadStatus = Images.Count().ToString() + " files uploaded successfully.";
                }
                else { s = "0"; break; }

            }

            ads.Images = s;
            db.Entry(ads);
            db.SaveChanges();

            return RedirectToAction("PersonalCabinet", "Home");
        }



        public ActionResult Openphone(int id, int? page, int? ex1, int? ex2, int? ex3, int? ex4, int? ex5, int? ex6, int? ex7, int? ex8,int? operation)
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            
            var ads = from a in db.Adses
                      select a;
            try
            {
                if (ex1 == null && ex2 == null)
                {
                    ads = db.Adses;
                }
            }
            catch { }
            try
            {
                if (ex1 != null && ex2 == null)
                {
                    ads = db.Adses.Where(x => x.CountRooms >= ex1);
                }
            }
            catch { }
            try
            {
                if (ex1 == null && ex2 != null)
                {
                    ads = db.Adses.Where(x => x.CountRooms <= ex2);
                }
            }
            catch { }
            try
            {
                if (ex1 != null && ex2 != null)
                {
                    ads = db.Adses.Where(x => x.CountRooms >= ex1 && x.CountRooms <= ex2);
                }
            }
            catch { }
            //------------------------------------------------------------------
            try
            {
                if (ex3 == null && ex4 == null)
                {
                }
            }
            catch { }
            try
            {
                if (ex3 != null && ex4 == null)
                {
                    ads = ads.Where(x => x.Floor >= ex3);
                }
            }
            catch { }
            try
            {
                if (ex3 == null && ex4 != null)
                {
                    ads = ads.Where(x => x.Floor <= ex4);
                }
            }
            catch { }
            try
            {
                if (ex3 != null && ex4 != null)
                {
                    ads = ads.Where(x => x.Floor >= ex3 && x.Floor <= ex4);
                }
            }
            catch { }

            //------------------------------------------------
            try
            {
                if (ex5 == null && ex6 == null)
                {
                }
            }
            catch { }
            try
            {
                if (ex5 != null && ex6 == null)
                {
                    ads = ads.Where(x => x.SquarePlace >= ex5);
                }
            }
            catch { }
            try
            {
                if (ex5 == null && ex6 != null)
                {
                    ads = ads.Where(x => x.SquarePlace <= ex5);
                }
            }
            catch { }
            try
            {
                if (ex5 != null && ex6 != null)
                {
                    ads = ads.Where(x => x.SquarePlace >= ex5 && x.SquarePlace <= ex6);
                }
            }
            catch { }
            //-----------------------------------------------
            try
            {
                if (ex7 == null && ex8 == null)
                {
                }
            }
            catch { }
            try
            {
                if (ex7 != null && ex8 == null)
                {
                    ads = ads.Where(x => x.Price >= ex7);
                }
            }
            catch { }
            try
            {
                if (ex7 == null && ex8 != null)
                {
                    ads = ads.Where(x => x.Price <= ex8);
                }
            }
            catch { }
            try
            {
                if (ex7 != null && ex8 != null)
                {
                    ads = ads.Where(x => x.Price >= ex7 && x.Price <= ex8);
                }
            }
            catch { }

            if (ads != null) {
                ViewBag.e1 = ex1;
                ViewBag.e2 = ex2;
                ViewBag.e3 = ex3;
                ViewBag.e4 = ex4;
                ViewBag.e5 = ex5;
                ViewBag.e6 = ex6;
                ViewBag.e7 = ex7;
                ViewBag.e8 = ex8;
                ViewBag.operation = operation;

                if (operation == null)
                {
                    operation = 0;
                }

                if (operation != 0)
                {
                    return View(ads.Where(x => x.Operation_Id == operation&&x.Sales==2).OrderByDescending(x => x.ID).ToPagedList(pageNumber, pageSize));
                }else
                    return View(ads.Where(x=>x.Sales==2).OrderByDescending(x => x.ID).ToPagedList(pageNumber, pageSize));
            }
            else
            if (id != 0)
            {
                return View(db.Adses.Where(m => m.Operation_Id == id&&m.Sales==2).OrderByDescending(x => x.ID).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(db.Adses.Where(z=>z.Sales==2).OrderByDescending(x=>x.ID).ToPagedList(pageNumber, pageSize));
            }
        }
        

        public ActionResult Details(int id)
        {
            ViewBag.ID = id;
            return View();
        }
        
        public ActionResult Exit()
        {
            Session["Active"] = "0";
            return RedirectToAction("login", "account");
        }

        public ActionResult PersonalCabinet(int? page)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);

            ViewBag.user = Session["user"];
            Users us = new Users();
            us.ID = ViewBag.user;

            //Adses ad = db.Adses.FirstOrDefault(m => m.User_Id == us.ID);
            try
            {
                if (us.ID == 1)
                {
                    return RedirectToAction("index", "cabinet");
                }
            }
            catch { }

            try
            {
                return View(db.Adses.Where(m => m.User_Id == us.ID).OrderByDescending(x => x.ID).ToPagedList(pageNumber, pageSize));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

       

        public ActionResult Edit(int id)
        {
            try
            {
                if (Session["Active"].ToString() != "1")
                    return RedirectToAction("login", "account");
            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            
            Adses ad=db.Adses.FirstOrDefault(m=>m.ID==id);
            ViewBag.ID = ad.ID;
            string a = ad.User_Id.ToString();
            string b = Session["us"].ToString();
            if (a != b) { return RedirectToAction("login","account"); }

            Session["Lang"] = 2;        
            return View(db.Adses.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Adses ad)
        {
            Adses ads = db.Adses.FirstOrDefault(x => x.ID == ad.ID);

            if (ads.Sales == 5)
            {
                ads.Sales = 4;
            }

            ads.CountRooms = ad.CountRooms;
            ads.Address = ad.Address;
            ads.All_Floor = ad.All_Floor;
            ads.Area_Id = ad.Area_Id;
            ads.Build_Id = ad.Build_Id;
            ads.Classification_Id = ad.Classification_Id;
            ads.Comissions = ad.Comissions;
            if (ad.Contacts_Id == null)
            {
                ads.Contacts_Id = 2;
            }
            ads.Floor = ad.Floor;
            ads.Furniture = ad.Furniture;
            if (ad.Images != null)
            {
                ads.Images = ad.Images;
            }
            ads.LivePlace = ad.LivePlace;
            ads.Operation_Id = ad.Operation_Id;
            ads.PhoneNumber = ad.PhoneNumber;
            ads.Price = ad.Price;
            ads.PriceType_Id = ad.PriceType_Id;
            ads.Property_Id = ad.Property_Id;
            ads.ShortText = ad.ShortText;
            ads.SquarePlace = ad.SquarePlace;
            ads.State_Id = ad.State_Id;
            ads.Title = ad.Title;
            if (ad.Top_Ads == null)
            {
                ads.Top_Ads = 2;
            }
            ads.Zone_Id = ad.Zone_Id;
            ads.Accept_Rejection = 0;
            ads.Date = DateTime.Now;

            db.Entry(ads);
            db.SaveChangesAsync();

            return RedirectToAction("PersonalCabinet");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                if (Session["Active"].ToString() != "1")
                    return RedirectToAction("login", "account");
            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            Adses ad = db.Adses.FirstOrDefault(m => m.ID == id);
            ViewBag.ID = ad.ID;
            string a = ad.User_Id.ToString();
            string b = Session["us"].ToString();
            if (a != b) { return RedirectToAction("login", "account"); }

            Session["Lang"] = 2;
            return View(db.Adses.Find(id));
        }
        [HttpPost]
        public ActionResult Delete(Adses ad)
        {
            Adses a = db.Adses.FirstOrDefault(x => x.ID == ad.ID);
            db.Adses.Remove(a);
            db.SaveChanges();

            return RedirectToAction("PersonalCabinet");
        }

        public ActionResult ChangePassword()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            Password pas = new Password();
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Password pas)
        {
            int id = Convert.ToInt32(Session["User"]);
            try
            {
                Users tmp = db.Users.FirstOrDefault(m => m.ID == id);
                if (tmp.Password == pas.OldPassword)
                {
                    if (pas.NewPassword == pas.EqualPassword)
                    {
                        ModelState.AddModelError("", "Пароль изменён.");
                        tmp.Password = pas.NewPassword;
                        db.Entry(tmp);
                        db.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Введенные пароли не совпадают.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Текущий пароль введен не верно.");
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            return View();
        }

    }
}