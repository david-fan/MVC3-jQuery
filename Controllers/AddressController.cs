using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook_mvc3_jQuery.Models;
using AddressBook_mvc3_jQuery.Data;
using AddressBook_mvc3_jQuery.Helpers;

namespace AddressBook_mvc3_jQuery.Controllers
{
    public class AddressController : Controller
    {

        public ActionResult Index(int personNo)
        {

            ViewBag.Message = "";
            
            Paginginfo pi = new Paginginfo();
            pi.id = personNo;
            pi.TotalCount = Repository.GetAddressList().Where(c => c.PersonNo == personNo).ToList().Count;
            pi.PageSize = 5;

            return View(pi);
        }


        //
        // GET: /Address/

        [HttpPost]
        public JsonResult GetAddressTypeList()
        {
            object obj = null;

            

            List<AddressType> list = Repository.GetAddressTypeList();
            obj = new { Success = true, Message = "OK", List= list };
            
            return Json(obj, JsonRequestBehavior.AllowGet);            
        }


       
        public JsonResult GetCountryList()
        {
            object obj = null;



            List<Country> list = Repository.GetCountryList();
            obj = new { Success = true, Message = "OK", List = list };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }


       
        public JsonResult GetCityList(int CountryNo)
        {
            object obj = null;


            List<City> list = Repository.GetCityList().Where(c => c.CountryNo == CountryNo).ToList(); ;
            obj = new { Success = true, Message = "OK", List = list };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
   

        public JsonResult GetAddressList(int personNo, int pageNo)
        {
            
            int pageSize = 5; //it could be parameter
            int skipCnt = ((pageNo - 1) * pageSize);

            List<Address> list = (from x in Repository.GetAddressList() where x.PersonNo == personNo orderby x.AddressNo descending select x).Skip(skipCnt).Take(pageSize).ToList();
           
            JsonResult jr = Json(new
            {
                Html = this.RenderPartialView("AddressList", list),                
                Message = "OK"
            }, JsonRequestBehavior.AllowGet);

            return jr;
        }


        [HttpGet]
        public ActionResult Save(int addressNo, int personNo)
        {
            Address address = new Address();
            address.AddressNo = 0;
            address.PersonNo = personNo;

            if (addressNo > 0)
            {
                address = Repository.GetAddressList().Where(c => c.AddressNo == addressNo).FirstOrDefault();
            }

            return PartialView(address);
        }


        [HttpPost]
        public JsonResult Save(FormCollection fc)
        {
            object obj = null;

                        
            Address addrTmp = new Address();
            addrTmp.AddressNo = Convert.ToInt32(fc["TBAddressNo"].ToString());
            addrTmp.AddressTypeNo = Convert.ToInt32(fc["CBAddressType"].ToString());
            addrTmp.AddressText = fc["TBAddressText"].ToString();
            addrTmp.CityNo = Convert.ToInt32(fc["CBcity"].ToString()); ;
            addrTmp.PersonNo = Convert.ToInt32(fc["TBPersonNo"].ToString()); 
            
            if (ModelState.IsValid)
            {
                if (addrTmp.AddressNo == 0)
                {
                    //find last person 
                    //if it is database system no need to this line. Probably the AddressNo would be autoincrement
                    addrTmp.AddressNo = Data.Repository.GetAddressList().OrderBy(x => x.AddressNo).Last().AddressNo + 1;

                    Data.Repository.GetAddressList().Add(addrTmp);
                    

                    obj = new { Success = true, 
                                Message = "Added successfully", 
                                Object = addrTmp, 
                                operationType = "INSERT",                                
                                Html = this.RenderPartialView("_addressLine", addrTmp )
                              };
                }
                else
                {
                    Address addr = Repository.GetAddressList().Where(c => c.AddressNo == addrTmp.AddressNo).FirstOrDefault();
                    addr.AddressTypeNo = addrTmp.AddressTypeNo;
                    addr.AddressText = addrTmp.AddressText;
                    addr.CityNo = addrTmp.CityNo;
                    addr.PersonNo = addrTmp.PersonNo;

                    obj = new { Success = true, 
                                Message = "Updated successfully", 
                                Object = addr, 
                                operationType = "UPDATE",                                
                                Html = this.RenderPartialView("_addressLine",  addr )
                              };
                }                

            }
            else
            {
                obj = new { Success = false, Message = "Please check form" };
            }

            return Json(obj, JsonRequestBehavior.DenyGet);
        }


        [HttpPost]
        public JsonResult DeleteAddress(int addressNo)
        {            
            string message = string.Empty;

            try
            {
                Address addr = Data.Repository.GetAddressList().Where(c => c.AddressNo == addressNo).FirstOrDefault();

                if (addr != null)
                {
                    Data.Repository.GetAddressList().Remove(addr);
                    message = "Address deleted";
                }
                else
                {
                    message = "Address not found!";
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
        }

    }
}
