using MealMonkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MealMonkey.Controllers
{
    public class HomeController : Controller
    {
        Freshers_Training2022Entities dt = new Freshers_Training2022Entities();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(MM_Contact con)
        {
            dt.MM_Contact.Add(con);
            dt.SaveChanges();
            ViewBag.Message = "Your messages has been sent";

            return RedirectToAction("ContactConfirm");
        }
        public ActionResult ContactConfirm()
        {
            ViewBag.Message = "Thank You For Your Valauable feedback we will react to you soon!!";

            return View();
        }
    }
}