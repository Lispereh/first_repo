using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_6_Store
{
    internal class Store
    {

        public string Name { get; set; }
        public Address StoreAddress;
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Store() : this("Unknown store's name", 
                              "Unknown store's description",
                              "Unknown store's phone number", 
                              "Unknown store's email",
                              "000000", "Country",
                              "City", 
                              "Street",
                              "Building") { }

        public Store(string name, string description,
                     string phoneNumber, string email,
                     string postcode, string country, string city,
                     string street, string building)
        {
            Name = name;
            StoreAddress = new Address(postcode, country, city,
                                        street, building);
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string ToString()
        {
            return $"Название магазина: {Name}\n" +
                   $"{StoreAddress}\n" +
                   $"Описание профиля магазина: {Description}\n" +
                   $"Контактный телефон: {PhoneNumber}\n" +
                   $"Контактный e-mail: {Email}";
        }

    }
}