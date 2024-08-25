using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_1_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Dictionary1 dictionary1 = new Dictionary1 { Name = "Англо-русский" };

            //dictionary1.CreateDictionary();

            //dictionary1.AddWord("Кошка", "животное");
            //dictionary1.AddWord("Кошка", "милая");
            //dictionary1.AddWord("Собака", "хищник");
            //dictionary1.AddWord("Кролик", "пушистый");

            //dictionary1.SearchDefinition("Кролик");

            //dictionary1.ReplaceWord("Собака", "Тигр");
            //dictionary1.SearchDefinition("Тигр");
            //dictionary1.SearchDefinition("Собака");

            //dictionary1.ChooseDefinitionForReplace("Кошка");
            //dictionary1.SearchDefinition("Кошка");

            //dictionary1.ChooseDefinitionForDelete("Кролик");
            //dictionary1.ChooseDefinitionForDelete("Кошка");
            //dictionary1.SearchDefinition("Кошка");

            //"D:\Русско-русский.txt"

            //FileReading file = new FileReading(@"D:\\Русско-русский.txt");
            //Dictionary1 dictionary1 = file.ReadFromFile();

            //dictionary1.PrintDictionary();

            Menu menu = new Menu();

            menu.ShowMenu();

            Console.ReadKey();
        }
    }
}