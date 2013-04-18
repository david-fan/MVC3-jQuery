using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AddressBook_mvc3_jQuery
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //--------------
            routes.MapRoute(
                "AddressSave",
                "Address/Save/{addressNo}/{personNo}",
                new { controller = "Address", action = "Save", 
                     addressNo = UrlParameter.Optional, personNo = UrlParameter.Optional }
            );
            //--------------


            //--------------
            routes.MapRoute(
                "AddressList",
                "Address/Index/{personNo}",
                new { controller = "Address", action = "Index", personNo = UrlParameter.Optional }
            );
            //--------------



            //--------------
            routes.MapRoute(
                "AddressDelete",
                "Address/DeleteAddress/{addressNo}",
                new { controller = "Address", action = "DeleteAddress", addressNo = UrlParameter.Optional }
            );
            //--------------

            //--------------
            routes.MapRoute(
                "PersonSave", // Route name
                "Person/Save/{personNo}", // URL with parameters
                new { controller = "Person", action = "Save", personNo = UrlParameter.Optional } // Parameter defaults
            );
            //--------------


            //--------------
            routes.MapRoute(
                "PersonDelete", // Route name
                "Person/DeletePerson/{personNo}", // URL with parameters
                new { controller = "Person", action = "DeletePerson", personNo = UrlParameter.Optional } // Parameter defaults
            );
            //--------------


            //--------------
            routes.MapRoute(
                "PersonPicSave", // Route name
                "Person/SavePersonPic/{personNo}", // URL with parameters
                new { controller = "Person", action = "SavePersonPic", personNo = UrlParameter.Optional } // Parameter defaults
            );
            //--------------



            //--------------
            routes.MapRoute(
                "NoteList", // Route name
                "Note/Index/{personNo}", // URL with parameters
                new { controller = "Note", action = "Index", personNo = UrlParameter.Optional } // Parameter defaults
                
            );
            //--------------


            //--------------
            routes.MapRoute(
                "NoteSave",
                "Note/Save/{noteNo}/{personNo}",
                new
                {
                    controller = "Note",
                    action = "Save",
                    addressNo = UrlParameter.Optional,
                    personNo = UrlParameter.Optional
                }
            );
            //--------------


            //--------------
            routes.MapRoute(
                "NoteDelete", // Route name
                "Note/DeleteNote/{noteNo}", // URL with parameters
                new { controller = "Note", action = "DeleteNote", noteNo = UrlParameter.Optional } // Parameter defaults

            );
            //--------------



            //--------------
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            //--------------

        


        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}