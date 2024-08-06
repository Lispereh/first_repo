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

            return magazine;
        }
    }
}