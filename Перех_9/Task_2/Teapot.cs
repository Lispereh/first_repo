using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_devices
{
    internal class Teapot : Device
    {
        private string _model;

        public Teapot() : base() 
        { 
            _model = "";
        }

        public Teapot(string name, string description, string sound, string model)
                      : base(name, description, sound) 
        { 
            _model = model;
        }


        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Модель: {_model}");
        }
    }
}