using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_2_Quiz_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PerformMenuActions performMenuActions = new PerformMenuActions();
            performMenuActions.WorkOfProgram();

            Console.ReadKey();
        }
    }
}