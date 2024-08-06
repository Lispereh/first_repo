using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Magazine
{
    internal class Magazine
    {
        public string Name { get; set; }
        public DateTime date;
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Magazine() : this("Unknown magazine's name",
                                 "Unknown magazine's description",
                                 "Unknown magazine's phone number",
                                 "Unknown magazine's email", 
                                 01, 01, 2000) { }

        public Magazine(string name, string description, 
                        string phoneNumber, string email,
                        int day, int month, int year)
        {
            Name = name;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
            date = new DateTime(year, month, day);
        }

        public override string ToString()
        {
            return $"Название журнала: \"{Name}\"\n" +
                   $"Дата основания: {date.ToShortDateString()}г.\n" + // вывод даты, без времени
                   $"Описание журнала: {Description}\n" +
                   $"Номер телефона: {PhoneNumber}\n" +
                   $"Email: {Email}";
        }
    }
}