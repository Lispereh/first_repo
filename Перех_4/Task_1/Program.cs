using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Square square = new Square('*', 5);

            Console.WriteLine("----- Заполненный квадрат -----\n");
            square.drawSquare();

            Console.WriteLine("\n----- Пустой квадрат -----\n");
            square.drawEmptySquare();

            Console.ReadKey();

        }
    }
}