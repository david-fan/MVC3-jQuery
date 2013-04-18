using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook_mvc3_jQuery.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
			MonoDBDriver.init();
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }



        public ActionResult About()
        {
            return View();
        }


    }
}
