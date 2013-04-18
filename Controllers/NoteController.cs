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
    public class NoteController : Controller
    {
        

        public ActionResult Index(int personNo)
        {
            ViewBag.Message = "";

            Paginginfo pi = new Paginginfo();
            pi.id = personNo;
            pi.TotalCount = Repository.GetNoteList().Where(c => c.PersonNo == personNo).ToList().Count;
            pi.PageSize = 5;

            return View(pi);
        }


        public JsonResult GetNoteList(int personNo,  int lastNoteNo)
        {
            int pageSize = 5; //it could be parameter
            bool hasMore = false;

            List<Note> list = null;

            if (lastNoteNo == 0)
            {            
                list = (from x in Repository.GetNoteList() where x.PersonNo == personNo orderby x.NoteNo descending select x).Take(pageSize).ToList();
                hasMore = (from x in Repository.GetNoteList() where x.PersonNo == personNo select x.NoteNo).Take(pageSize + 1).Count() - pageSize > 0;
            }
            else
            {
                list = (from x in Repository.GetNoteList() where x.NoteNo < lastNoteNo && x.PersonNo == personNo orderby x.NoteNo descending select x).Take(pageSize).ToList();
                hasMore = (from x in Repository.GetNoteList() where x.NoteNo < lastNoteNo && x.PersonNo == personNo select x.NoteNo).Take(pageSize + 1).Count() - pageSize > 0;
            }
            
            JsonResult jr = Json(new
            {
                Html = this.RenderPartialView("_NoteList", list),
                Message = "OK",
                HasMore = hasMore
            }, JsonRequestBehavior.AllowGet);

            return jr;
        }

        


        [HttpGet]
        public ActionResult Save(int noteNo, int personNo)
        {
            Note note = new Note();
            note.NoteNo = 0;
            note.PersonNo = personNo;

            if (noteNo > 0)
            {
                note = Repository.GetNoteList().Where(c => c.NoteNo == noteNo).FirstOrDefault();
            }

            return PartialView(note);
        }


        [HttpPost]
        public JsonResult Save(Note n)
        {
            object obj = null;
            
            if (ModelState.IsValid)
            {
                if (n.NoteNo == 0)
                {
                    //find last note 
                    //if it is database system no need to this line. Probably the NoteNo would be autoincrement
                    n.NoteNo = Data.Repository.GetNoteList().OrderBy(x => x.NoteNo).Last().NoteNo + 1;                    
                    Data.Repository.GetNoteList().Add(n);

                    

                    obj = new { Success = true, 
                                Message = "Saved successfully", 
                                Object = n, 
                                operationType = "INSERT",                                
                                Html = this.RenderPartialView("_noteLine", n)
                                };

                }
                else
                {
                    Note note = Repository.GetNoteList().Where(c => c.NoteNo == n.NoteNo).FirstOrDefault();
                    note.NoteText = n.NoteText;
                    
                    obj = new { Success = true, 
                                Message = "Saved successfully", 
                                Object = note, 
                                operationType = "UPDATE",                               
                                Html = this.RenderPartialView("_noteLine", note )
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
        public JsonResult DeleteNote(int noteNo)
        {
        
            string message = string.Empty;

            try
            {
                Note n = Data.Repository.GetNoteList().Where(c => c.NoteNo == noteNo).FirstOrDefault();

                if (n != null)
                {
                    Data.Repository.GetNoteList().Remove(n);
                    message = "Deleted";
                }
                else
                {
                    message = "Note not found!";
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult DeleteALL(string noteNOs)
        {   
                     
            string message = string.Empty;
            char[] seps = {','};
            string[] noteNoArray = noteNOs.Split(seps);

            message = "ALL selecteds are deleted";

            try
            {
                int noteNo = 0;

                for (int i = 0; i < noteNoArray.Length; i++)
                {

                        noteNo = Convert.ToInt32(noteNoArray[i]);

                         Note n = Data.Repository.GetNoteList().Where(c => c.NoteNo == noteNo).FirstOrDefault();

                        if (n != null)
                        {
                            Data.Repository.GetNoteList().Remove(n);                            
                        }
                        else
                        {
                            message = "fail at delete";                            
                        }          
                }//for

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);

        }

                      
    }
}
