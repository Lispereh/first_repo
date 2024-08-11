using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_workers
{
    internal class Worker
    {
        public virtual void Print()
        {
            Console.Write($"The position of the employee is ");
        }
    }
}