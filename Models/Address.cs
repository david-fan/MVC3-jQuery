using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook_mvc3_jQuery.Models
{
    public class Address
    {
        //----------------------------------------------

        public int AddressNo { set; get; }
        public int PersonNo { set; get; }
        public int AddressTypeNo { set; get; }
        public int CityNo { set; get; }
        public string AddressText { set; get; }

        //----------------------------------------------

        
        public string CityName
        {
            get {
                if (CityNo > 0)
                    return Data.Repository.GetCityList().Where(c => c.CityNo == CityNo).FirstOrDefault().CityName;
                else
                    return "";
                }
        }


        public string AddressTypeName
        {
            get {
                    if (AddressTypeNo > 0)
                        return Data.Repository.GetAddressTypeList().Where(c => c.AddressTypeNo == AddressTypeNo).FirstOrDefault().AddressTypeName;
                    else
                        return "";
                }
        }

        public int CountryNo
        {
            get {
                if (CityNo > 0)
                    return Data.Repository.GetCityList().Where(c => c.CityNo == CityNo).FirstOrDefault().CountryNo;
                else
                    return 0;
                }
        }

        public string CountryName
        {
            get {
                if (CountryNo > 0)
                    return Data.Repository.GetCountryList().Where(c => c.CountryNo == this.CountryNo).FirstOrDefault().CountryName;
                else
                    return "";
                }
        }


        //----------------------------------------------

    }
}