using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Exam_Task_1_Dictionary
{
    internal class Menu
    {
        private WorkWithDictionary _workWithDictionary;

        public string CreateDictionaryMenu()
        {
            Console.Write("Укажите тип словаря: ");
            string name = Console.ReadLine();

            return name;
        }

        public string OpenDictionaryMenu()
        {
            Console.Write("Укажите путь к файлу словаря: ");
            string path = Console.ReadLine();

            return path;
        }

        public void FirstMenu()
        {
            Console.WriteLine("----- Меню -----\n" +
                              "1. Создать словарь\n" +
                              "2. Открыть словарь\n");
        }

        public void DictionaryActionMenu()
        {
            Console.WriteLine("\n1. Добавить слово и перевод\n" +
                              "2. Заменить слово\n" +
                              "3. Заменить перевод\n" +
                              "4. Удалить слово\n" +
                              "5. Удалить перевод\n" +
                              "6. Искать перевод слова\n" +
                              "7. Выход из программы\n");
        }

        public void ChooseFirstAction()
        {
            FirstMenu();

            Console.Write("Выберите код меню: ");
            int action = Convert.ToInt32(Console.ReadLine());

            //do
            //{
            //    if (action < 1 || action > 2)
            //    {
            //        Console.WriteLine("Ошибка. Повторите попытку\n");

            //        FirstMenu();

            //        Console.Write("Выберите код меню: ");
            //        action = Convert.ToInt32(Console.ReadLine());
            //    }
            //} while (action != 1 || action != 2);

            _workWithDictionary = new WorkWithDictionary();

            if(action == 1)
            {
                string name = CreateDictionaryMenu();
                _workWithDictionary.CreateDictionary(name);
            }
            else if (action == 2)
            {
                string path = OpenDictionaryMenu();
                _workWithDictionary.OpenDictionary(path);
            }
        }

        public void ChooseSecondAction()
        {
            DictionaryActionMenu();

            Console.Write("Выберите код меню: ");
            int action = Convert.ToInt32(Console.ReadLine());

            //do
            //{
            //    DictionaryActionMenu();

            //    Console.Write("Выберите код меню: ");
            //    action = Convert.ToInt32(Console.ReadLine());

            //    if (action < 1 || action > 7)
            //        Console.WriteLine("Ошибка. Повторите попытку");
            //    if (action == 7)
            //        break;
            //    else
            //        DoingDictionaryActions(action);
            //} while (action < 1 || action > 7);

            DoingDictionaryActions(action);
        }

        public void DoingDictionaryActions(int action)
        {
            if (action == 1)
                _workWithDictionary.AddValue();
            else if (action == 2)
                _workWithDictionary.ChangeWord();
            else if (action == 3)
                _workWithDictionary.ChangeDefinition();
            else if (action == 4)
                _workWithDictionary.RemoveWord();
            else if (action == 5)
                _workWithDictionary.RemoveDefinition();
            else if (action == 6)
                _workWithDictionary.SearchForDefinition();
        }

        public void ShowMenu()
        {
            ChooseFirstAction();
            ChooseSecondAction();
        }

    }
}