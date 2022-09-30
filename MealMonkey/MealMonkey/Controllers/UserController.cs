using MealMonkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MealMonkey.Controllers
{
    public class UserController : Controller
    {
        
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(MM_User account)
        {
            if (ModelState.IsValid)
            {
                using (masterEntities adb = new masterEntities())
                {
                    adb.MM_User.Add(account);
                    adb.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Name + "Successfully Registered";
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MM_User user)
        {
            using (masterEntities adb = new masterEntities())
            {
                try
                {
                    var login_user = adb.MM_User.Single(u => u.Email == user.Email && u.Password == user.Password);
                    if (login_user != null)
                    {
                        Session["UserId"] = login_user.UserId;
                        //Console.WriteLine(Session["UserId"]);
                        Session["Username"] = login_user.Username.ToString();
                        FormsAuthentication.SetAuthCookie(login_user.Username,true);
                        return RedirectToAction("Index","Products");

                    }

                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Username or Password is incorrect");

                    ///throw;
                }


            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}