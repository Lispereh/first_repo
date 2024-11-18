using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Id}, {ProductName}, {ProductType}, {Cost}, {Price}, {Quantity}";
        }

        public static Product FromString(string id, string productName,
                                         string productType, string cost, 
                                         string price, string quantity)
        {
            return new Product()
            {
                Id = Convert.ToInt32(id),
                ProductName = productName,
                ProductType = productType,
                Cost = Convert.ToDecimal(cost),
                Price = Convert.ToDecimal(price),
                Quantity = Convert.ToInt32(quantity)
            };
        }
    }
}