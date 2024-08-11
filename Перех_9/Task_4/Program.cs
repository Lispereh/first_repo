using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_workers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Worker[] workers =
            {
                new President(),
                new Security(),
                new Manager(),
                new Engineer()
            };

            foreach (Worker worker in workers)
                worker.Print();

            Console.ReadKey();
        }
    }
}