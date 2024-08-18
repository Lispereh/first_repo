using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Task_Exam
{
    internal class ChooseMenuActions
    {
        private Menu _menu;

        public ChooseMenuActions()
        {
            _menu = new Menu();
        }

        public int UseFirstMenu()
        {
            int firstMenuCode = 0;
            do
            {
                _menu.ShowFirstMenu();
                Console.Write("Выберите код меню: ");
                firstMenuCode = Convert.ToInt32(Console.ReadLine());

                if (firstMenuCode < 1 || firstMenuCode > 2)
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
            } while(firstMenuCode < 1 || firstMenuCode > 2);

            return firstMenuCode;
        }

        public int UseMenuForNewDictionary()
        {
            int newDictionaryMenuCode = 0;

            do
            {
                _menu.ShowMenuForNewDictionary();
                Console.Write("Выберите код меню: ");
                newDictionaryMenuCode = Convert.ToInt32(Console.ReadLine());

                if (newDictionaryMenuCode < 1 || newDictionaryMenuCode > 2)
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
            } while (newDictionaryMenuCode < 1 || newDictionaryMenuCode > 2);

            return newDictionaryMenuCode;
        }

        public int UseMainMenu()
        {
            int mainMenuCode = 0;

            do
            {
                _menu.ShowMainMenu();
                Console.Write("Выберите код меню: ");
                mainMenuCode = Convert.ToInt32(Console.ReadLine());

                if (mainMenuCode < 1 || mainMenuCode > 7)
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
            } while (mainMenuCode < 1 || mainMenuCode > 7);

            return mainMenuCode;
        }
    }
}