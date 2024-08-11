using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_devices
{
    internal class Device
    {

        protected string name;
        protected string sound;
        protected string description;

        public Device() : this("", "", "") { }

        public Device(string name, string description, string sound) 
        {
            this.name = name;
            this.description = description;
            this.sound = sound;
        }

        public void Sound()
        {
            Console.WriteLine($"Звук: {sound}-{sound}");
        }

        public void Show()
        {
            Console.WriteLine($"----- {name} ------");
        }

        public void Desc()
        {
            Console.WriteLine($"Описание: {description}");
        }

        public virtual void Print()
        {
            Show();
            Desc();
            Sound();
        }
    }
}