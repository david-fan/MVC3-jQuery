using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook_mvc3_jQuery.Models;
using AddressBook_mvc3_jQuery.Data;

namespace AddressBook_mvc3_jQuery.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /Person/

        public ActionResult PersonList()
        {
            List<Person> list = Data.Repository.GetPersonList();
            return View(list);            
        }

       

        [HttpGet]
        public ActionResult Save(int personNo)
        {
            
            Person person= new Person();
            //person.BirthDate = DateTime.Today;
            person.BirthDate = DateTime.Today;

            //String.Format("{0:dd/mm/yyyy}", person.BirthDate);

            person.PersonNo = 0;
            
            if (personNo > 0)
            {
                person = Repository.GetPersonList().Where(c => c.PersonNo == personNo).FirstOrDefault();                
            }

            return PartialView(person);

        }


        [HttpPost]
        public JsonResult Save(Person p)
        {
            object obj = null;
           
            if (ModelState.IsValid)
            {
                if (p.PersonNo == 0) // INSERT
                {
                    
                    //find last person 
                    //if it is database system no need to this line. Probably the PersonNo would be autoincrement
                    p.PersonNo = Data.Repository.GetPersonList().OrderBy(x => x.PersonNo).Last().PersonNo + 1; 
          

                    Data.Repository.GetPersonList().Add(p);
                                                            
                    obj = new { Success = true, Message = "Saved successfully", Object = p, operationType="INSERT" };
                }
                else // UPDATE
                {
                    Person person = Repository.GetPersonList().Where(c => c.PersonNo == p.PersonNo).FirstOrDefault();
                    person.FirstName = p.FirstName;
                    person.LastName = p.LastName;
                    person.CategoryNo = p.CategoryNo;
                    person.BirthDate = p.BirthDate;
                                        
                    obj = new { Success = true, Message = "Updated successfully", Object = person, operationType = "UPDATE" };
                }                               
            }
            else
            {
                obj = new { Success = false, Message = "Please check form"};
                
            }

            return Json(obj, JsonRequestBehavior.DenyGet);
        }


        [HttpPost]
        public JsonResult DeletePerson(int personNo)
        {
            
            string message = string.Empty;

            try
            {
                Person p = Data.Repository.GetPersonList().Where(c => c.PersonNo == personNo).FirstOrDefault();

                if (p != null)
                {
                    Data.Repository.GetPersonList().Remove(p);
                    message = "Deleted";
                }
                else
                {
                    message = "Person not found!";
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Json( new{Message = message}, JsonRequestBehavior.AllowGet);
        }


        //-------------- image -----


        [HttpGet]
        public ActionResult SavePersonPic(int personNo)
        {

            Person person = new Person();
                        
            if (personNo > 0)
            {
                person = Repository.GetPersonList().Where(c => c.PersonNo == personNo).FirstOrDefault();
            }

            return PartialView(person);
        }


        [HttpPost]        
        public JsonResult SavePersonPic(HttpPostedFileBase file,                                        
                                        int personNo)
        {                
                string message = string.Empty;
                bool success = false;
                string imgPath = "";
                string fileName = "";
                try
                {
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), 
                                    System.IO.Path.GetFileName(file.FileName));
                    file.SaveAs(path);

                    Person p = Data.Repository.GetPersonList().Where(r => r.PersonNo == personNo).FirstOrDefault();
                    p.imgFileName = file.FileName;
                    ViewBag.Message = "File uploaded successfully";
                    message = ViewBag.Message;

                    fileName = file.FileName;
                    imgPath = Url.Content(String.Format("~/Content/images/{0}", fileName)); 
                    
                    success = true;

                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    success = true;
                    imgPath = "";
                    fileName = "";
                }


                return Json(
                                new { Success = success, 
                                      Message = message, 
                                      PersonNo=personNo,
                                      ImagePath = imgPath,
                                      FileName = fileName
                                    }, 
                                JsonRequestBehavior.AllowGet
                            );

        }

        //------------- /image --------

    }
}
