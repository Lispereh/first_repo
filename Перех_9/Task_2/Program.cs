using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_2_devices
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Device[] devices =
            {
                new Teapot("Чайник",
                           "устройство для кипячения воды и заваривания чая",
                           "свист",
                           "Polaris PWK 1725 CGLD"),
                new Nuke("Микроволновая печь",
                         "устройство для быстрого приготовления, " +
                         "подогрева или размораживания пищи",
                         "бип",
                         "60х60х45"),
                new Car("Автомобиль",
                        "устройство для преобразования энергии, " +
                        "материалов и информации",
                        "врум",
                        2020),
                new Steamboat("Пароход",
                              "устройство, оснащённое поршневой " +
                              "паровой машиной или паровой турбиной " +
                              "в качестве тягового двигателя",
                              "туу",
                              137936.7)
            };

            foreach (Device device in devices)
            {
                device.Print();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}