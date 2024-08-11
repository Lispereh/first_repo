using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_2_devices
{
    internal class Nuke : Device
    {

        private string _size;

        public Nuke() : base()
        {
            _size = "";
        }

        public Nuke(string name, string description, string sound, string size)
                      : base(name, description, sound)
        {
            _size = size;
        }


        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Размер: {_size} см");
        }

    }
}