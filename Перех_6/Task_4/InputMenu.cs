using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_Website
{
    internal class InputMenu
    {
        private string _name = "";
        private string _url = "";
        private string _description = "";
        private string _ip = "";

        public Website CreateEmptySite()
        {
            return new Website();
        }

        public Website CreateParametersSite() 
        {
            return new Website
            {
                Name = "Site 1",
                Url = "www.site1.ru",
                Description = "Site 1 description",
                IPAddress = "169.233.115.173"
            };
        }

        public void Input()
        {
            Console.Write("Введите название сайта: ");
            _name = Console.ReadLine();

            Console.Write("Введите путь к сайту: ");
            _url = Console.ReadLine();

            Console.Write("Введите описание сайта: ");
            _description = Console.ReadLine();

            Console.Write("Введите IP адрес сайта: ");
            _ip = Console.ReadLine();
        }

        public Website CreateInputParametersSite() 
        {
            Input();

            return new Website
            {
                Name = _name,
                Url = _url,
                Description = _description,
                IPAddress = _ip
            };
        }

        public Website SetParametersSite(Website website)
        {
            Input();

            website.Name = _name;
            website.Url = _url;
            website.Description = _description;
            website.IPAddress = _ip;

            return website;
        }
    }
}