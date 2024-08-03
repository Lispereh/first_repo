using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    internal class InputMenu
    {
        Store store;
        private string _name = "";
        private int _postcode = 0;
        private string _country = "";
        private string _city = "";
        private string _street = "";
        private string _building = "";
        private string _description = "";
        private string _phoneNumber = "";
        private string _email = "";

        public void inputName()
        {
            Console.WriteLine("----- Ввод информации о магазине -----\n");
            Console.Write("Введите название магазина: ");
            _name = Console.ReadLine();
        }

        public void inputPostcode()
        {
            Console.Write("Введите почтовый индекс магазина: ");
            _postcode = Convert.ToInt32(Console.ReadLine());
        }

        public void inputCountry()
        {
            Console.Write("Введите страну магазина: ");
            _country = Console.ReadLine();
        }

        public void inputCity()
        {
            Console.Write("Введите город магазина: ");
            _city = Console.ReadLine();
        }

        public void inputStreet()
        {
            Console.Write("Введите улицу магазина: ");
            _street = Console.ReadLine();
        }

        public void inputBuilding()
        {
            Console.Write("Введите дом / строение магазина: ");
            _building = Console.ReadLine();
        }

        public void inputDescription()
        {
            Console.Write("Введите описание профиля магазина: ");
            _description = Console.ReadLine();
        }

        public void inputPhoneNumber()
        {
            Console.Write("Введите контактный телефон магазина: ");
            _phoneNumber = Console.ReadLine();
        }

        public void inputEmail()
        {
            Console.Write("Введите контактный e-mail магазина: ");
            _email = Console.ReadLine();
        }

        public void enterData()
        {
            inputName();
            inputPostcode();
            inputCountry();
            inputCity();
            inputStreet();
            inputBuilding();
            inputDescription();
            inputPhoneNumber();
            inputEmail();
        }

        public void createStoreParametersConstructor()
        {
            store = new Store(_name, _description, _phoneNumber, _email,
                              _postcode, _country, _city, _street, _building);
        }

        public void showWithPrint()
        {
            enterData();
            Console.WriteLine();
            createStoreParametersConstructor();

            Console.WriteLine($"----- Информация о магазине \"{_name}\" -----\n");
            store.printStoreParameters();
            Console.WriteLine('\n');
        }

        public void createStoreEmptyConstructor()
        {
            store = new Store();
        }

        public void fillWithSet() 
        { 
            store.setStoreName(_name);
            store.setStoreDescription(_description);
            store.setStorePhoneNumber(_phoneNumber);
            store.setStoreEmail(_email);
            store.setStoreAddress(_postcode, _country, _city, _street, _building);
        }

        public void showStoreParametersWithGet()
        {
            Console.WriteLine($"----- Информация о магазине \"{_name}\" -----\n");
            Console.WriteLine($"Название магазина: {store.getStoreName()}");

            Console.WriteLine($"Адрес магазина: {store.getStorePostcode()}, " +
                              $"{store.getStoreCountry()}, {store.getStoreCity()}, " +
                              $"{store.getStoreStreet()}, {store.getStoreBuilding()}");

            Console.WriteLine($"Описание профиля магазина: {store.getStoreDescription()}");
            Console.WriteLine($"Контактный телефон: {store.getStorePhoneNumber()}");
            Console.WriteLine($"Контактный e-mail: {store.getStoreEmail()}");
        }

        public void showWithGet()
        {
            enterData();
            Console.WriteLine();
            createStoreEmptyConstructor();
            fillWithSet();
            showStoreParametersWithGet();
        }
    }
}