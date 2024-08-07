using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_5_Magazine
{
    internal class Magazine
    {
        public string Name { get; set; }
        public DateTime date;
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Employees { get; set; }

        public Magazine() : this("Unknown magazine's name",
                                 "Unknown magazine's description",
                                 "Unknown magazine's phone number",
                                 "Unknown magazine's email", 
                                 01, 01, 2000, 0) { }

        public Magazine(string name, string description, 
                        string phoneNumber, string email,
                        int day, int month, int year, int employees)
        {
            Name = name;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
            date = new DateTime(year, month, day);
            Employees = employees;
        }

        public static Magazine operator +(Magazine magazine, int number)
        {
            return new Magazine
            {
                Name = magazine.Name,
                Description = magazine.Description,
                PhoneNumber = magazine.PhoneNumber,
                Email = magazine.Email,
                date = magazine.date,
                Employees = magazine.Employees + number
            };
        }

        public static Magazine operator -(Magazine magazine, int number)
        {
            return new Magazine
            {
                Name = magazine.Name,
                Description = magazine.Description,
                PhoneNumber = magazine.PhoneNumber,
                Email = magazine.Email,
                date = magazine.date,
                Employees = magazine.Employees - number
            };
        }

        public void PrintResult()
        {
            Console.WriteLine($"Количество сотрудников журнала \"{Name}\" " +
                              $"составляет {Employees} человек\n");
        }

        public override bool Equals(Object o)
        {
            return this.ToString() == o.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Magazine magazine1, Magazine magazine2)
        {
            return (magazine1.Employees).Equals(magazine2.Employees);
        }

        public static bool operator !=(Magazine magazine1, Magazine magazine2)
        {
            return !(magazine1.Employees).Equals(magazine2.Employees);
        }

        public static bool operator >(Magazine magazine1, Magazine magazine2)
        {
            return magazine1.Employees > magazine2.Employees;
        }

        public static bool operator <(Magazine magazine1, Magazine magazine2)
        {
            return magazine1.Employees < magazine2.Employees;
        }

        public override string ToString()
        {
            return $"Название журнала: \"{Name}\"\n" +
                   $"Дата основания: {date.ToShortDateString()}г.\n" + // вывод даты, без времени
                   $"Описание журнала: {Description}\n" +
                   $"Номер телефона: {PhoneNumber}\n" +
                   $"Email: {Email}\n" +
                   $"Количество сотрудников: {Employees}";
        }
    }
}