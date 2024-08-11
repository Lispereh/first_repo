using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_devices
{
    internal class Car : Device
    {

        private int _releaseYear;

        public Car() : base()
        {
            _releaseYear = 1990;
        }

        public Car(string name, string description, string sound, int releaseYear)
                      : base(name, description, sound)
        {
            _releaseYear = releaseYear;
        }


        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Год выпуска: {_releaseYear}");
        }

    }
}