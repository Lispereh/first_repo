using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5_Magazine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            InputMenu inputMenu = new InputMenu();

            Magazine magazine1 = inputMenu.CreateEmptyMagazine();
            Console.WriteLine("----- Пустой журнал -----\n\n" + magazine1 + "\n\n");

            Magazine magazine2 = inputMenu.CreateParametersMagazine();
            Console.WriteLine("----- Журнал с параметрами -----\n\n" + magazine2 + "\n\n");

            Console.WriteLine("----- Смена параметров пустого журнала -----\n");
            magazine1 = inputMenu.SetParametersMagazine(magazine1);
            Console.WriteLine("\n\n----- Журнал с изменёнными параметрами -----\n\n" + magazine1 + "\n\n");

            Console.WriteLine("----- Заполнение данных о журнале -----\n");
            Magazine magazine3 = inputMenu.CreateInputParametersMagazine();
            Console.WriteLine("\n\n----- Журнал с параметрами -----\n\n" + magazine3 + "\n\n");

            inputMenu.OperatorOverloading(magazine1, magazine2);

            Console.ReadKey();
        }
    }
}