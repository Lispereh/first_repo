using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_2_devices
{
    internal class Steamboat : Device
    {

        private double _weight;

        public Steamboat() : base()
        {
            _weight = 0.5;
        }

        public Steamboat(string name, string description, string sound, double weight)
                      : base(name, description, sound)
        {
            _weight = weight;
        }


        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Вес: {_weight} тонн");
        }

    }
}