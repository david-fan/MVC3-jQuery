using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace AddressBook_mvc3_jQuery.Controllers
{
	public class PlanController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "";
			
			JibenXinxi pi = new JibenXinxi();
			pi.Subject="Test Subject!";
			
			return View(pi);
		}
	}

}

