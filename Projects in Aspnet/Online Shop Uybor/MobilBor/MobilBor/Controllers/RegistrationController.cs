using MobilBor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilBor.Controllers
{
    public class RegistrationController : Controller
    {
        mobilborEntities db = new mobilborEntities();
        // GET: Registration
        public ActionResult Register(int? a)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register()
        {
            Users u = new Users();
            u.FullName = Convert.ToString(Request.Form["Name"]);
            u.Country = Convert.ToString(Request.Form["Country"]);
            //u.Email = Convert.ToString(Request.Form["Email"]);
            u.Phone = Convert.ToString(Request.Form["PhoneNumber"]);
            u.Login = Convert.ToString(Request.Form["Username"]);
            u.Password = Convert.ToString(Request.Form["Password"]);
            u.Email = u.Login;
            u.Type = 1;
            u.UserType = 3;
            
            db.Users.Add(u);
            db.SaveChanges();

            Session["Active"] = "1";
            Session["User"] = u.ID;
            Session["Type"] = u.Type;

            if (Session["Active"] == "1")
            {
                return RedirectToAction("PersonalCabinet", "Home");
            }
          
            return RedirectToAction("Login", "Account");
        }

        public JsonResult CheckUserNameAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SearchData = db.Users.Where(x => x.Login == userdata).SingleOrDefault();
            if (SearchData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

    }
}