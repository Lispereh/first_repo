using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6_Store
{
    internal class Address
    {

        public string Postcode {  get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }

        public Address() : this("000000", "Country", 
                                "City",
                                "Street", 
                                "Building") { }

        public Address(string postcode, string country,
                       string city, string street,
                       string building)
        {
            Postcode = postcode;
            Country = country;
            City = city;
            Street = street;
            Building = building;
        }

        public override string ToString()
        {
            return $"Адрес магазина: {Postcode}, {Country}, " +
                   $"{City}, {Street}, {Building}";
        }

    }
}