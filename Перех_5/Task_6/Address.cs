using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    internal class Address
    {
        private int _postcode;
        private string _country;
        private string _city;
        private string _street;
        private string _building;

        public Address() : this(000000, "Страна", "Город",
                                "Улица", "Дом / строение") { }

        public Address(int postcode, string country, 
                       string city, string street, 
                       string building)
        {
            _postcode = postcode;
            _country = country;
            _city = city;
            _street = street;
            _building = building;
        }

        public void setPostCode(int postcode)
        {
            _postcode = postcode;
        }

        public int getPostCode()
        {
            return _postcode;
        }

        public void setCountry(string country) 
        {
            _country = country;
        }

        public string getCountry()
        {
            return _country;
        }

        public void setCity(string city)
        {
            _city = city;
        }

        public string getCity()
        {
            return _city;
        }

        public void setStreet(string street)
        {
            _street = street;
        }

        public string getStreet()
        {
            return _street;
        }

        public void setBuilding(string building)
        {
            _building = building;
        }

        public string getBuilding()
        {
            return _building;
        }

        public void printAddress()
        {
            Console.WriteLine($"Адрес магазина: {_postcode}, {_country}, {_city}, " +
                              $"{_street}, {_building}");
        }
    }
}