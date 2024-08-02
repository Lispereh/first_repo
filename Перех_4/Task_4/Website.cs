using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Task_4
{
    internal class Website
    {

        private string name;
        private string url;
        private string siteDescription;
        private string ip;

        public Website(string nameP, string urlP,
                       string siteDescriptionP, string ipP)
        {
            name = nameP;
            url = urlP;
            siteDescription = siteDescriptionP;
            ip = ipP;
        }

        public Website()
        {
            name = "";
            url = "";
            siteDescription = "";
            ip = "";
        }

        public void setName(string nameP)
        {
            name = nameP;
        }

        public void setUrl(string urlP)
        {
            url = urlP;
        }

        public void setSiteDescription(string siteDescriptionP)
        {
            siteDescription = siteDescriptionP;
        }

        public void setIp(string ipP)
        {
            ip = ipP;
        }

        public string getName()
        {
            return name;
        }

        public string getUrl()
        {
            return url;
        }

        public string getSiteDescription()
        {
            return siteDescription;
        }

        public string getIp()
        {
            return ip;
        }

        public void print()
        {
            Console.WriteLine("Название сайта: " + getName());
            Console.WriteLine("Путь к сайту: " + getUrl());
            Console.WriteLine("Описание сайта: " + getSiteDescription());
            Console.WriteLine("IP адрес сайта: " + getIp());
        }
    }
}