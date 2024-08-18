using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Task_Exam
{
    internal class Menu
    {
        public void ShowFirstMenu()
        {
            Console.WriteLine("----- Меню -----\n");
            Console.WriteLine("1. Создать словарь");
            Console.WriteLine("2. Открыть словарь из файла\n");
        }

        public void ShowMenuForNewDictionary()
        {
            Console.WriteLine("----- Меню -----\n");
            Console.WriteLine("1. Добавить слово и его перевод");
            Console.WriteLine("2. Завершить\n");
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("----- Меню -----\n");
            Console.WriteLine("1. Добавить слово и его перевод");
            Console.WriteLine("2. Заменить слово");
            Console.WriteLine("3. Заменить перевод слова");
            Console.WriteLine("4. Удалить слово");
            Console.WriteLine("5. Удалить перевод");
            Console.WriteLine("6. Искать перевод слова");
            Console.WriteLine("7. Завершить\n");
        }
    }
}