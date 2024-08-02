using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Website site1 = new Website("Site 1", "www.site1.ru", 
                                        "Site 1 description", "169.233.115.173");

            Console.WriteLine("Название сайта: " + site1.getName());
            Console.WriteLine("Путь к сайту: " + site1.getUrl());
            Console.WriteLine("Описание сайта: " + site1.getSiteDescription());
            Console.WriteLine("IP адрес сайта: " + site1.getIp());

            Website site2 = new Website();

            site2.setName("Site 2");
            site2.setUrl("www.site2.ru");
            site2.setSiteDescription("Site 2 description");
            site2.setIp("204.40.244.29");

            Console.WriteLine("\n");
            site2.print();

            Console.ReadKey();
        }
    }
}