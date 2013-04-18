using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook_mvc3_jQuery.Models
{
    public class Paginginfo
    {
        public int id { set; get; }
        public int TotalCount { set; get; }
        public int PageSize { set; get; }
    }
}