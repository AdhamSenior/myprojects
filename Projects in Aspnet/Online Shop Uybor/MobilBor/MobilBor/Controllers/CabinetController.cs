using MobilBor.Models;
using MobilBor.Models.Class;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilBor.Controllers
{
    public class CabinetController : Controller
    {
        mobilborEntities db = new mobilborEntities();

        public ActionResult Proba()
        {
            foreach (var items in db.Adses)
            {
                if (items.Date.Value.AddMonths(1).CompareTo(DateTime.Now) < 0)
                {
                    items.Sales = 3;
                    items.Accept_Rejection = 3;
                }
                db.Entry(items);
            }

            db.SaveChanges();

            return View(db.Adses);
        }
        
        public ActionResult Index()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            return View();
        }

        public ActionResult Add()
        {
            Session["Lang"] = 1;
            Adses ads = new Adses();

            return View(ads);
        }

        [HttpPost]
        public ActionResult Add(Adses ads, HttpPostedFileBase[] Images)
        {
            string s = "";
            int count = 0;

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

                ads.User_Id = 1;
            ads.Accept_Rejection = 0;

                db.Adses.Add(ads);
                db.SaveChanges();

             

                foreach (HttpPostedFileBase files in Images)
                {
                if (count > 8) { break; }
                count++;
                //Checking file is available to save.  
                if (files != null)
                    {
                        var InputFileName = Path.GetFileName(files.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + ads.ID + "-" + InputFileName);
                        s += Convert.ToString(ads.ID) + "-" + InputFileName + ",";

                        //Save file to server folder  
                        files.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = Images.Count().ToString() + " files uploaded successfully.";
                    }
                else { s = "0"; break; }

                }

                ads.Images = s;
                db.Entry(ads);
                db.SaveChanges();
            
            return RedirectToAction("Add", "Cabinet");
        }
        public ActionResult AddSecond()
        {
            Session["Lang"] = 1;
            Adses ads = new Adses();

            return View(ads);
        }
        [HttpPost]
        public ActionResult AddSecond(Adses ads, HttpPostedFileBase[] Images)
        {
            string s = "";

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

            ads.User_Id = 1;

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

            return RedirectToAction("AddSecond", "Cabinet");
        }

        public ActionResult IndexNew(int? count_room)
        {
            if (count_room != 0 && count_room != null)
            {
                return View(db.Adses.Where(x => x.Sales == 2 && x.CountRooms==count_room));
            }
            else
            {
                return View(db.Adses.Where(x => x.Sales == 2));
            }
        }

            

        



        public ActionResult Sales_Ads()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");
            }
            catch
            {
                return RedirectToAction("login", "account");
            }
           
            return View(db.Adses.Where(x => x.Sales == 1));

        }

        public ActionResult IndexOld()
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            return View(db.Adses.Where(x => x.Sales == 3));
        }

        public ActionResult Users(int? page)
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

            return View(db.Users.Where(x=>x.UserType==2).OrderByDescending(x => x.ID).ToPagedList(pageNumber, pageSize));
        }

        public new ActionResult User(int? page)
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

            return View(db.Users.Where(x=>x.UserType==3).OrderByDescending(x => x.ID).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int id)
        {

            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.ID = id;
            return View();
        }
        [HttpPost]
        public ActionResult Details(Adses a)
        {
            Adses aa = db.Adses.FirstOrDefault(x => x.ID == a.ID);

            if (aa.Sales == 3)
            {
                aa.Date = DateTime.Now;
                aa.Sales = 1;
            }
            db.Entry(aa);
            db.SaveChanges();

           return RedirectToAction("IndexNew");
        }

        public ActionResult Edit(int id)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            Session["Lang"] = 2;
            
            return View(db.Adses.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Adses ph)
        {
            Adses p=db.Adses.FirstOrDefault(x=>x.ID==ph.ID);

            p.CountRooms = ph.CountRooms;
            p.Address = ph.Address;
            p.All_Floor = ph.All_Floor;
            p.Area_Id = ph.Area_Id;
            p.Build_Id = ph.Build_Id;
            p.Classification_Id = ph.Classification_Id;
            p.Comissions = ph.Comissions;
            if (ph.Contacts_Id == null)
            {
                p.Contacts_Id = 2;
            }
            p.Floor = ph.Floor;
            p.Furniture = ph.Furniture;
            if (ph.Images != null)
            {
                p.Images = ph.Images;
            }
            p.LivePlace = ph.LivePlace;
            p.Operation_Id = ph.Operation_Id;
            p.PhoneNumber = ph.PhoneNumber;
            p.Price = ph.Price;
            p.PriceType_Id = ph.PriceType_Id;
            p.Property_Id = ph.Property_Id;
            p.ShortText = ph.ShortText;
            p.SquarePlace = ph.SquarePlace;
            p.State_Id = ph.State_Id;
            p.Title = ph.Title;
            if (ph.Top_Ads == null)
            {
                p.Top_Ads = 2;
            }
            p.Zone_Id = ph.Zone_Id;

            db.Entry(p);
            db.SaveChangesAsync();

            if (p.Sales==2) { return RedirectToAction("IndexNew"); }
            else { return RedirectToAction("IndexOld"); }


        }

        public ActionResult Delete(int id)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.ID = id;
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Adses ph)
        {
            Adses a = db.Adses.FirstOrDefault(x => x.ID == ph.ID);
            db.Adses.Remove(a);
            db.SaveChanges();

            if (a.Sales == 3)
            {
                return RedirectToAction("IndexOld");
            }
            else if (a.Sales == 1)
            {
                return RedirectToAction("Sales_Ads");
            }
            else
            {
                return RedirectToAction("IndexNew");
            }

        }

        public ActionResult Exit()
        {
            Session["Active"] = "0";
            return RedirectToAction("login", "account");
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

        public ActionResult ContactUs(int? page)
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

            return View(db.Contact.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ContactUsDetails(int id)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }

            return View(db.Contact.FirstOrDefault(x=>x.Id==id));
        }

        //public ActionResult Really(int id)
        //{
        //    return View(db.Users.FirstOrDefault(x => x.ID == id));
        //}
        
        public ActionResult Really(int id)
        {
            Users uu = db.Users.FirstOrDefault(x => x.ID == id);

            if (uu.Type == 1)
            {
                uu.Type = 2;
            }
            else
            {
                uu.Type = 1;
            }

            db.Entry(uu);
            db.SaveChanges();
            //db.Users.Remove(uu);
            //db.SaveChanges();

            if (uu.UserType == 2)
            { 
                return RedirectToAction("Users");
            }
                return RedirectToAction("User");
        }

        public ActionResult NewAdses()
        {
            return View(db.Adses.Where(x=>x.Sales==4));
        }

        public ActionResult Except(int id)
        {
            Adses a = db.Adses.FirstOrDefault(x => x.ID == id);

            a.Sales = 2;
            a.Date = DateTime.Now;

            db.Entry(a);
            db.SaveChanges();

            if (a.Sales == 3)
            {
                return RedirectToAction("IndexOld");
            }
            else
            {
                return RedirectToAction("newAdses");
            }

        }

        public ActionResult Buy(int id)
        {
            Adses a = db.Adses.FirstOrDefault(x => x.ID == id);

            
            a.Date = DateTime.Now;

            db.Entry(a);
            db.SaveChanges();
            if (a.Sales == 2)
            {
                a.Sales = 1;
                return RedirectToAction("IndexNew");
            }
            else
            {
                return RedirectToAction("IndexOld");
            }
        }

        public ActionResult Reject_Ads()
        {
            return View(db.Adses.Where(x => x.Sales == 5));
        }

        public ActionResult Reject(int id)
        {
            return View(db.Adses.FirstOrDefault(x => x.ID == id));
        }
        [HttpPost]
        public ActionResult Rejection(Adses a)
        {
            Adses aa = db.Adses.FirstOrDefault(x => x.ID == a.ID);

            aa.Sales = 5;
            aa.Date = DateTime.Now;
            try
            {
                aa.About_Mistake = a.About_Mistake;
            }
            catch { }

            db.Entry(aa);
            db.SaveChanges();

            return RedirectToAction("newAdses");
        }

        public ActionResult AddUsers()
        {
            Session["Lang"] = 1;
            Users us = new Users();

            return View(us);
        }

        [HttpPost]
        public ActionResult AddUsers(Users usr)
        {
            usr.Type = 1;
            usr.UserType = 2;
            db.Users.Add(usr);
            db.SaveChanges();

            return RedirectToAction("Users", "Cabinet");
        }

        public ActionResult EditUsers(int id)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            Session["Lang"] = 2;

            return View(db.Users.Find(id));
        }
        [HttpPost]
        public ActionResult EditUsers(Users ph)
        {
            Users p = db.Users.FirstOrDefault(x => x.ID == ph.ID);

            p.FullName = ph.FullName;
            p.Email = ph.Email;
            p.Country = ph.Country;
            p.Login = ph.Login;
            p.Password = ph.Password;
            p.Phone = ph.Phone;
            
            db.Entry(p);
            db.SaveChanges();

            return RedirectToAction("Users");
        }

        public ActionResult DeleteUsers(int id)
        {
            try
            {
                if (Session["Active"].ToString() != "1") return RedirectToAction("login", "account");

            }
            catch
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.ID = id;
            return View(db.Users.FirstOrDefault(x=>x.ID==id));
        }
        [HttpPost]
        public ActionResult DeleteUsers(Users ph)
        {
            Users a = db.Users.FirstOrDefault(x => x.ID == ph.ID);
            db.Users.Remove(a);
            db.SaveChanges();

            if (a.UserType == 2) { 
                foreach(var items in db.Adses.Where(x => x.User_Id == ph.ID))
                {
                    items.User_Id = 1;
                    db.Entry(items);
                }
                db.SaveChanges();
            return RedirectToAction("Users");
            }

            else if(a.UserType==3)
            {
                foreach (var items in db.Adses.Where(x => x.User_Id == ph.ID))
                {
                    db.Adses.Remove(items);
                }
                db.SaveChanges();

                return RedirectToAction("User");
            }

            return RedirectToAction("User");
        }

        public ActionResult Furik_Barchart()
        {


            return View();
        }

        public ActionResult Furik_BarchartGroup()
        {


            return View();
        }

        public ActionResult Furik_BarchartGrop2()
        {


            return View();
        }

        public ActionResult Furik_GraphArea()
        {


            return View();
        }


    }
}