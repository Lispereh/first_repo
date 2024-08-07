using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Magazine
{
    internal class InputMenu
    {

        private string _name = "";
        private string _description = "";
        private int _day = 0;
        private int _month = 0;
        private int _year = 0;
        private string _phoneNumber = "";
        private string _email = "";
        private int _employees = 0;

        public Magazine CreateEmptyMagazine()
        {
            return new Magazine();
        }

        public Magazine CreateParametersMagazine()
        {
            return new Magazine
            {
                Name = "Vogue",
                Description = "Женский журнал о моде",
                PhoneNumber = "+7 495 745-55-65",
                Email = "help@vogue.com",
                date = new DateTime(1892, 12, 17),
                Employees = 5
            };
        }

        public void InputInformation()
        {
            Console.Write("Введите название журнала: ");
            _name = Console.ReadLine();

            Console.Write("Введите описание журнала: ");
            _description = Console.ReadLine();

            Console.Write("Введите день основания журнала: ");
            _day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите месяц основания журнала: ");
            _month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите год основания журнала: ");
            _year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Укажите телефон журнала: ");
            _phoneNumber = Console.ReadLine();

            Console.Write("Укажите email журнала: ");
            _email = Console.ReadLine();

            Console.Write("Укажите количество сотрудников: ");
            _employees = Convert.ToInt32(Console.ReadLine());
        }

        public Magazine CreateInputParametersMagazine()
        {
            InputInformation();

            return new Magazine
            {
                Name = _name,
                Description = _description,
                PhoneNumber = _phoneNumber,
                Email = _email,
                date = new DateTime(_year, _month, _day),
                Employees = _employees
            };
        }

        public Magazine SetParametersMagazine(Magazine magazine)
        {
            InputInformation();

            magazine.Name = _name;
            magazine.Description = _description;
            magazine.date = new DateTime(_year, _month, _day);
            magazine.PhoneNumber = _phoneNumber;
            magazine.Email = _email;
            magazine.Employees = _employees;

            return magazine;
        }

        public void OperatorOverloading(Magazine magazine1, Magazine magazine2)
        {
            Console.Write("Введите количество для увеличения штата: ");
            int number1 = Convert.ToInt32(Console.ReadLine());

            magazine1 = magazine1 + number1;
            magazine1.PrintResult();

            Console.Write("Введите количество для уменьшения штата: ");
            int number2 = Convert.ToInt32(Console.ReadLine());

            magazine1 = magazine1 - number2;
            magazine1.PrintResult();

            Console.WriteLine($"Equals(magazine1.Employees, magazine2.Employees): " +
                              $"{magazine1.Equals(magazine2)}\n");

            Console.WriteLine($"magazine1.Employees == magazine2.Employees: " +
                              $"{magazine1 == magazine2}");

            Console.WriteLine($"magazine1.Employees != magazine2.Employees: " +
                              $"{magazine1 != magazine2}\n");

            Console.WriteLine($"magazine1.Employees > magazine2.Employees: " +
                              $"{magazine1 > magazine2}");

            Console.WriteLine($"magazine1.Employees < magazine2.Employees: " +
                              $"{magazine1 < magazine2}");
        }
    }
}