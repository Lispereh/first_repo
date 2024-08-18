using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Task_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoMenuActions doMenuActions = new DoMenuActions();
            doMenuActions.WorkOfProgram();

            Console.ReadKey();
        }
    }
}