using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    internal class Store
    {

        private string _storeName;
        private Address _storeAddress;
        private string _storeDescription;
        private string _storePhoneNumber;
        private string _storeEmail;

        public Store() : this("Название", "Описание профиля",
                              "Номер телефона", "Эл. почта",
                              000000, "Страна", "Город", "Улица", 
                              "Дом / строение") { }

        public Store(string storeName, string storeDescription, 
                     string storePhoneNumber, string storeEmail,
                     int postcode, string country, string city,
                     string street, string building)
        {
            _storeName = storeName;
            _storeAddress = new Address(postcode, country, city,
                                        street, building);
            _storeDescription = storeDescription;
            _storePhoneNumber = storePhoneNumber;
            _storeEmail = storeEmail;
        }

        public void setStoreName(string storeName)
        {
            _storeName = storeName;
        }

        public string getStoreName()
        {
            return _storeName;
        }

        public void setStoreDescription(string storeDescription)
        {
            _storeDescription = storeDescription;
        }

        public string getStoreDescription() 
        {
            return _storeDescription;
        }

        public void setStorePhoneNumber(string storePhoneNumber)
        {
            _storePhoneNumber = storePhoneNumber;
        }

        public string getStorePhoneNumber()
        {
            return _storePhoneNumber;
        }

        public void setStoreEmail(string storeEmail)
        {
            _storeEmail = storeEmail;
        }

        public string getStoreEmail()
        {
            return _storeEmail;
        }

        public void setStoreAddress(int postcode, string country, string city,
                                    string street, string building)
        {
            _storeAddress.setPostCode(postcode);
            _storeAddress.setCountry(country);
            _storeAddress.setCity(city);
            _storeAddress.setStreet(street);
            _storeAddress.setBuilding(building);
        }

        public int getStorePostcode()
        {
            return _storeAddress.getPostCode();
        }

        public string getStoreCountry()
        {
            return _storeAddress.getCountry();
        }

        public string getStoreCity()
        {
            return _storeAddress.getCity();
        }

        public string getStoreStreet()
        {
            return _storeAddress.getStreet();
        }

        public string getStoreBuilding()
        {
            return _storeAddress.getBuilding();
        }

        public void printStoreParameters()
        {
            Console.WriteLine($"Название магазина: {_storeName}");
            _storeAddress.printAddress();
            Console.WriteLine($"Описание профиля магазина: {_storeDescription}");
            Console.WriteLine($"Контактный телефон: {_storePhoneNumber}");
            Console.WriteLine($"Контактный e-mail: {_storeEmail}");
        }
    }
}