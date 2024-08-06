using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {

            InputMenu inputMenu = new InputMenu();

            Store store1 = inputMenu.CreateEmptyStore();
            Console.WriteLine("----- Пустой магазин -----\n\n" + store1 + "\n\n");

            Console.WriteLine("----- Смена параметров пустого магазина -----\n");
            store1 = inputMenu.SetParametersStore(store1);
            Console.WriteLine("\n\n----- Магазин с изменёнными параметрами -----\n\n" + store1 + "\n\n");

            Store store2 = inputMenu.CreateParametersStore();

            Console.WriteLine("----- Магазин с параметрами -----\n\n" + store2 + "\n\n");

            Console.WriteLine("----- Заполнение данных о магазине -----\n");
            Store store3 = inputMenu.CreateInputParametersStore();
            Console.WriteLine("\n\n----- Магазин с параметрами -----\n\n" + store3);

            Console.ReadKey();
        }
    }
}