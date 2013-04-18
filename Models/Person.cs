using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AddressBook_mvc3_jQuery.Models
{
    public class Person
    {
        
        public int PersonNo { set; get; }

        [Required(ErrorMessage = "CategoryNo is Requried")]
        public int CategoryNo { set; get; }

        [Required(ErrorMessage = "FirstName is Requried")]
        public string FirstName { set; get; }

        [Required(ErrorMessage = "LastName is Requried")]
        public string LastName { set; get; }


        [Required(ErrorMessage = "BirthDate is Requried")]
        [DataType(DataType.Date)]        
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { set; get; }

        public string imgFileName;

        public string ImgFileName 
        {
            get {
                    if (this.imgFileName == "")
                        return "noimg.jpg";
                    else
                        return this.imgFileName;
                }

            set { }
        
        }

        //----------------------------------------------

        public List<Category> CategoryList
        {
            get { return Data.Repository.GetCategoryList() ; }            
        }


        public string CategoryName
        {
            get { return Data.Repository.GetCategoryList().Where(c => c.CategoryNo == CategoryNo).FirstOrDefault().CategoryName; }
        }

        //----------------------------------------------

    }
}