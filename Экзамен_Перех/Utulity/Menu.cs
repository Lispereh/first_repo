using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editing_Utility
{
    internal class Menu
    {
        public void MainEditingMenu()
        {
            Console.WriteLine("----- Меню -----\n");
            Console.WriteLine("1. Редактировать вопросы");
            Console.WriteLine("2. Редактировать ответы");
            Console.WriteLine("3. Выход\n");
        }

        public int ChoiceCodeMenu()
        {

            Console.Write("Введите код меню: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        public void ShowQuizesList()
        {
            Console.WriteLine("----- Меню викторин -----\n");
            Console.WriteLine("1. Тема: Основные понятия ООП");
            Console.WriteLine("2. Тема: Классы, структуры");
            Console.WriteLine("3. Тема: Коллекции");
            Console.WriteLine("4. Выход\n");
        }
    }
}