using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook_mvc3_jQuery.Models;
using AddressBook_mvc3_jQuery.Data;

namespace AddressBook_mvc3_jQuery.Controllers
{
    public class CommonController : Controller
    {
       
        [HttpGet]
        public ActionResult _personinfo(int personNo)
        {

            Person person = new Person();

            if (personNo > 0)
            {
                person = Repository.GetPersonList().Where(c => c.PersonNo == personNo).FirstOrDefault();
            }

            return PartialView(person);
        }

    }
}
