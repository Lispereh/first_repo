﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_workers
{
    internal class Engineer : Worker
    {
        public override void Print()
        {
            base.Print();
            Console.Write("an Engineer\n");
        }
    }
}