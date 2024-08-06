using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_Website
{
    internal class Program
    {
        static void Main(string[] args)
        {

            InputMenu inputMenu = new InputMenu();

            Website website1 = inputMenu.CreateEmptySite();
            Console.WriteLine("----- Пустой сайт -----\n\n" + website1 + "\n\n");

            Console.WriteLine("----- Смена параметров пустого сайта -----\n");
            website1 = inputMenu.SetParametersSite(website1);
            Console.WriteLine("\n\n----- Сайт с изменёнными параметрами -----\n\n" + website1 + "\n\n");

            Website website2 = inputMenu.CreateParametersSite();

            Console.WriteLine("----- Сайт с параметрами -----\n\n" + website2 + "\n\n");

            Console.WriteLine("----- Заполнение данных о сайте -----\n");
            Website website3 = inputMenu.CreateInputParametersSite();
            Console.WriteLine("\n\n----- Сайт с параметрами -----\n\n" + website3);

            Console.ReadKey();
        }
    }
}