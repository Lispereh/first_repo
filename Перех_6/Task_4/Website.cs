using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4_Website
{
    internal class Website
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string IPAddress { get; set; }

        public Website() : this("Unknow website", 
                                "Unknow website's url",
                                "Unknow website's description",
                                "Unknow website's IP address") { }

        public Website(string name, string url, string description, string ip)
        {
            Name = name;
            Url = url;
            Description = description;
            IPAddress = ip;
        }

        public override string ToString()
        {
            return $"Название сайта: {Name}\n" +
                   $"Путь к сайту: {Url}\n" +
                   $"Описание сайта: {Description}\n" +
                   $"IP адрес сайта: {IPAddress}";
        }
    }
}