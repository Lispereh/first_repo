using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Task_6_Store
{
    internal class InputMenu
    {

        private string _name = "";
        private string _postcode = "000000";
        private string _country = "";
        private string _city = "";
        private string _street = "";
        private string _building = "";
        private string _description = "";
        private string _phoneNumber = "";
        private string _email = "";

        public Store CreateEmptyStore()
        {
            return new Store();
        }

        public Store CreateParametersStore()
        {
            return new Store
            {
                Name = "Пятерочка",
                StoreAddress = new Address
                {
                    Postcode = "191025",
                    Country = "Россия",
                    City = "Санкт-Петербург",
                    Street = "Невский пр-кт",
                    Building = "д. 90/92"
                },
                Description = "Торговля розничная прочая в неспециализированных магазинах",
                PhoneNumber = "8-800-555-55-05",
                Email = "service@hoegl.ru"
            };
        }

        public void InputInformation()
        {
            Console.Write("Введите название магазина: ");
            _name = Console.ReadLine();

            Console.Write("Введите почтовый индекс магазина: ");
            _postcode = Console.ReadLine();

            Console.Write("Введите страну магазина: ");
            _country = Console.ReadLine();

            Console.Write("Введите город магазина: ");
            _city = Console.ReadLine();

            Console.Write("Введите улицу магазина: ");
            _street = Console.ReadLine();

            Console.Write("Введите дом / строение магазина: ");
            _building = Console.ReadLine();

            Console.Write("Введите описание профиля магазина: ");
            _description = Console.ReadLine();

            Console.Write("Введите контактный телефон магазина: ");
            _phoneNumber = Console.ReadLine();

            Console.Write("Введите контактный e-mail магазина: ");
            _email = Console.ReadLine();
        }

        public Store CreateInputParametersStore()
        {
            InputInformation();
            return new Store
            {
                Name = _name,
                StoreAddress = new Address
                {
                    Postcode = _postcode,
                    Country = _country,
                    City = _city,
                    Street = _street,
                    Building = _building
                },
                Description = _description,
                PhoneNumber = _phoneNumber,
                Email = _email
            };
        }

        public Store SetParametersStore(Store store)
        {
            InputInformation();
            store.Name = _name;
            store.StoreAddress = new Address
            {
                Postcode = _postcode,
                Country = _country,
                City = _city,
                Street = _street,
                Building = _building
            };
            store.Description = _description;
            store.PhoneNumber = _phoneNumber;
            store.Email = _email;

            return store;
        }
    }
}