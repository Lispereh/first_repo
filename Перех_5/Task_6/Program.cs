using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            InputMenu store1 = new InputMenu();
            store1.showWithPrint();

            InputMenu store2 = new InputMenu();
            store2.showWithGet();

            Console.ReadLine();

        }
    }
}