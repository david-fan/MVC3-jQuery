using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressBook_mvc3_jQuery.Models;

namespace AddressBook_mvc3_jQuery.Data
{
    public class Repository
    {
        static List<Category> CategoryList;

        static List<Person> PersonList;
        static List<Address> AddressList;
        static List<Note> NoteList;
        static List<AddressType> AddressTypeList;
        static List<Country> CountryList;
        static List<City> CityList;

        static Repository()
        {
            CategoryList = new List<Category>();
            PersonList = new List<Person>();
            AddressTypeList = new List<AddressType>();
            CountryList = new List<Country>();
            CityList = new List<City>();
            AddressList = new List<Address>();
            NoteList = new List<Note>();

            CountryList.Add(new Country { CountryNo = 1, CountryName = "TR" });
            CountryList.Add(new Country { CountryNo = 2, CountryName = "GB" });
            CountryList.Add(new Country { CountryNo = 3, CountryName = "GR" });


            CityList.Add(new City { CityNo = 1, CountryNo = 1, CityName = "Adana" });
            CityList.Add(new City { CityNo = 2, CountryNo = 1, CityName = "Ankara" });
            CityList.Add(new City { CityNo = 3, CountryNo = 1, CityName = "Bursa" });

            CityList.Add(new City { CityNo = 4, CountryNo = 2, CityName = "Cambridge" });
            CityList.Add(new City { CityNo = 5, CountryNo = 2, CityName = "Manchester" });
            CityList.Add(new City { CityNo = 6, CountryNo = 2, CityName = "Liverpool" });

            CityList.Add(new City { CityNo = 7, CountryNo = 3, CityName = "Hamburg" });
            CityList.Add(new City { CityNo = 8, CountryNo = 3, CityName = "Munih" });
            CityList.Add(new City { CityNo = 9, CountryNo = 3, CityName = "Stuttgart" });
            CityList.Add(new City { CityNo = 10, CountryNo = 3, CityName = "Dortmund" });

            CityList.Add(new City { CityNo = 11, CountryNo = 1, CityName = "Kocaeli" });
            CityList.Add(new City { CityNo = 12, CountryNo = 1, CityName = "Artvin" });
            CityList.Add(new City { CityNo = 13, CountryNo = 1, CityName = "Mardin" });

            CategoryList.Add(new Category { CategoryNo = 1, CategoryName = "Team" });
            CategoryList.Add(new Category { CategoryNo = 2, CategoryName = "Friend" });
            CategoryList.Add(new Category { CategoryNo = 3, CategoryName = "Others" });

            DateTime refBirthDate = new DateTime(1975, 5, 4);

            PersonList.Add(new Person { PersonNo = 1, CategoryNo = 1, FirstName = "alessandro", LastName = "del piero", BirthDate = refBirthDate.AddDays(340), imgFileName = "delpiero.jpg" });
            PersonList.Add(new Person { PersonNo = 2, CategoryNo = 2, FirstName = "zinedine", LastName = "zidane", BirthDate = refBirthDate.AddDays(670), imgFileName = "zz.jpg" });
            PersonList.Add(new Person { PersonNo = 3, CategoryNo = 1, FirstName = "Lionel", LastName = "messi", BirthDate = refBirthDate.AddDays(2300), imgFileName = "" });
            PersonList.Add(new Person { PersonNo = 4, CategoryNo = 1, FirstName = "roberto", LastName = "carlos", BirthDate = refBirthDate.AddDays(1000), imgFileName = "" });
            PersonList.Add(new Person { PersonNo = 5, CategoryNo = 1, FirstName = "christiano", LastName = "ronaldo", BirthDate = refBirthDate.AddDays(3400), imgFileName = "" });
            PersonList.Add(new Person { PersonNo = 6, CategoryNo = 2, FirstName = "George", LastName = "Hagi", BirthDate = refBirthDate.AddDays(-1040), imgFileName = "" });
            PersonList.Add(new Person { PersonNo = 7, CategoryNo = 2, FirstName = "Didier", LastName = "Drogba", BirthDate = refBirthDate.AddDays(-800), imgFileName = "" });
            PersonList.Add(new Person { PersonNo = 8, CategoryNo = 2, FirstName = "Zlatan", LastName = "ibrahimovic", BirthDate = refBirthDate.AddDays(700), imgFileName = "" });
            PersonList.Add(new Person { PersonNo = 9, CategoryNo = 1, FirstName = "ernest", LastName = "hemingway", BirthDate = refBirthDate.AddDays(-8000), imgFileName = "" });
            PersonList.Add(new Person { PersonNo = 10, CategoryNo = 1, FirstName = "john", LastName = "steinbeck", BirthDate = refBirthDate.AddDays(-3400), imgFileName = "" });
            PersonList.Add(new Person { PersonNo = 11, CategoryNo = 1, FirstName = "emile", LastName = "zola", BirthDate = refBirthDate.AddDays(-1500), imgFileName = "" });
            PersonList.Add(new Person { PersonNo = 12, CategoryNo = 1, FirstName = "david", LastName = "backham", BirthDate = refBirthDate.AddDays(3000), imgFileName = "" });
          

            AddressTypeList.Add(new AddressType { AddressTypeNo = 1, AddressTypeName = "Home" });
            AddressTypeList.Add(new AddressType { AddressTypeNo = 2, AddressTypeName = "Work" });


            AddressList.Add(new Address { AddressNo = 1, AddressTypeNo = 1, AddressText = "home address for person 1", PersonNo = 1, CityNo = 1 });
            AddressList.Add(new Address { AddressNo = 2, AddressTypeNo = 2, AddressText = "work address for person 1", PersonNo = 1, CityNo = 9 });
            AddressList.Add(new Address { AddressNo = 3, AddressTypeNo = 1, AddressText = "home address for person 2", PersonNo = 2, CityNo = 3 });
            AddressList.Add(new Address { AddressNo = 4, AddressTypeNo = 1, AddressText = "home address for person 1", PersonNo = 1, CityNo = 1 });
            AddressList.Add(new Address { AddressNo = 5, AddressTypeNo = 2, AddressText = "work address for person 1", PersonNo = 1, CityNo = 2 });
            AddressList.Add(new Address { AddressNo = 6, AddressTypeNo = 1, AddressText = "home address for person 2", PersonNo = 1, CityNo = 3 });
            AddressList.Add(new Address { AddressNo = 7, AddressTypeNo = 1, AddressText = "home address for person 1", PersonNo = 1, CityNo = 4 });
            AddressList.Add(new Address { AddressNo = 8, AddressTypeNo = 2, AddressText = "work address for person 1", PersonNo = 1, CityNo = 5 });
            AddressList.Add(new Address { AddressNo = 9, AddressTypeNo = 1, AddressText = "home address for person 2", PersonNo = 1, CityNo = 6 });
            AddressList.Add(new Address { AddressNo = 10, AddressTypeNo = 1, AddressText = "home address for person 1", PersonNo = 1, CityNo = 7 });
            AddressList.Add(new Address { AddressNo = 11, AddressTypeNo = 2, AddressText = "work address for person 1", PersonNo = 1, CityNo = 8 });
            AddressList.Add(new Address { AddressNo = 12, AddressTypeNo = 1, AddressText = "home address for person 2", PersonNo = 1, CityNo = 10 });
            AddressList.Add(new Address { AddressNo = 13, AddressTypeNo = 1, AddressText = "home address for person 1", PersonNo = 1, CityNo = 11 });
            AddressList.Add(new Address { AddressNo = 14, AddressTypeNo = 2, AddressText = "work address for person 1", PersonNo = 1, CityNo = 12 });
            AddressList.Add(new Address { AddressNo = 15, AddressTypeNo = 1, AddressText = "home address for person 2", PersonNo = 1, CityNo = 13 });




            NoteList.Add(new Note { NoteNo = 1, NoteText = "note 1 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 2, NoteText = "note 2 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 3, NoteText = "note 3 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 4, NoteText = "note 4 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 5, NoteText = "note 5 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 6, NoteText = "note 6 for person 2", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 7, NoteText = "note 7 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 8, NoteText = "note 8 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 9, NoteText = "note 9 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 10, NoteText = "note 10 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 11, NoteText = "note 11 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 12, NoteText = "note 12 for person 2", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 13, NoteText = "note 13 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 14, NoteText = "note 14 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 15, NoteText = "note 15 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 16, NoteText = "note 16 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 17, NoteText = "note 17 for person 1", PersonNo = 1 });
            NoteList.Add(new Note { NoteNo = 18, NoteText = "note 1 for person 2", PersonNo = 2 });
            NoteList.Add(new Note { NoteNo = 19, NoteText = "note 2 for person 2", PersonNo = 2 });

        }


        public static List<Person> GetPersonList()
        {
            return PersonList;
        }


        public static List<Address> GetAddressList()
        {
            return AddressList;
        }


        public static List<Note> GetNoteList()
        {
            return NoteList;
        }


        public static List<Category> GetCategoryList()
        {
            return CategoryList;
        }


        public static List<AddressType> GetAddressTypeList()
        {
            return AddressTypeList;
        }

        public static List<Country> GetCountryList()
        {
            return CountryList;
        }


        public static List<City> GetCityList()
        {
            return CityList;
        }

    }
}