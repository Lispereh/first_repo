using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Task_Exam
{
    internal class DoMenuActions
    {
        private ChooseMenuActions _chooseMenuActions;
        private Glossary _dictionary;
        private ReadFromFile _readFile;
        private WriteToFile _writeToFile;
        private int _firstMenuCode;
        private int _newDictionaryMenuCode;
        private int _mainMenuCode;

        public DoMenuActions()
        {
            _chooseMenuActions = new ChooseMenuActions();
        }

        public void WorkOfProgram()
        {
            DoFirstMenuActions();

            if (_firstMenuCode == 1)
                DoMenuForNewDictionaryActions();

            int exitCode = 1;

            do
            {
                DoMainMenuActions();

                Console.WriteLine("\nПродолжить? 1 - да, 2 - нет");
                Console.Write("Выберите код меню: ");
                exitCode = Convert.ToInt32(Console.ReadLine());

                if (exitCode != 1 && exitCode != 2)
                {
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
                    Console.WriteLine("\nПродолжить? 1 - да, 2 - нет");
                    Console.Write("Выберите код меню: ");
                    exitCode = Convert.ToInt32(Console.ReadLine());
                }

                Console.Clear();
            } while(exitCode == 1);
        }

        public void DoFirstMenuActions()
        {
            _firstMenuCode = _chooseMenuActions.UseFirstMenu();

            if (_firstMenuCode == 1)
                CreateDictionary();
            else
                OpenFileDictionary();
        }

        public void DoMenuForNewDictionaryActions()
        {
            _newDictionaryMenuCode = _chooseMenuActions.UseMenuForNewDictionary();
            AddWordAction();
        }

        public void DoMainMenuActions()
        {
            _mainMenuCode = _chooseMenuActions.UseMainMenu();

            if (_mainMenuCode == 7)
                return;
            else if (_mainMenuCode == 1)
                AddWordAction();
            else if (_mainMenuCode == 2)
                ChangeWordAction();
            else if (_mainMenuCode == 3)
                ChangeTranslationAction();
            else if (_mainMenuCode == 4)
                DeleteWordAction();
            else if (_mainMenuCode == 5)
                DeleteTranslationAction();
            else if (_mainMenuCode == 6)
                SearchTranslationAction();
        }

        public void CreateDictionary()
        {
            Console.WriteLine("\n----- Создание словаря -----");
            Console.Write("Введите название словаря: ");
            string name = Console.ReadLine();

            _dictionary = new Glossary(name);
            Console.WriteLine($"\nСоздан словарь " +
                              $"с названием \"{_dictionary.Name}\"\n");
        }

        public void OpenFileDictionary()
        {
            Console.WriteLine("\n----- Открытие словаря из файла -----");
            Console.Write("Введите путь к файлу: ");
            string path = Console.ReadLine();
            _readFile = new ReadFromFile(path);

            _dictionary = _readFile.Reading();
            Console.WriteLine($"\nОткрыт словарь " +
                              $"под названием \"{_dictionary.Name}\"\n");
        }

        public void AddWordAction()
        {
            Console.WriteLine("\n----- Добавление слова в словарь -----\n");
            Console.Write("Введите слово: ");
            string word = Console.ReadLine();
            Console.Write("Введите перевод слова: ");
            string translation = Console.ReadLine();

            _dictionary.AddWord(word, translation);

            Console.Write("\nРезультат добавления слова в словарь: ");
            _dictionary.SearchTranslation(word);
            Console.WriteLine();
        }

        public void ChangeWordAction()
        {
            Console.WriteLine("\n----- Замена слова -----\n");
            Console.Write("Введите слово, которое необходимо заменить: ");
            string oldWord = Console.ReadLine();
            Console.Write("Введите слово, на которое необходимо заменить: ");
            string newWord = Console.ReadLine();

            _dictionary.ChangeWord(oldWord, newWord);

            Console.Write("\nРезультат замены слова: ");
            _dictionary.SearchTranslation(newWord);
            Console.WriteLine();
        }

        public void ChangeTranslationAction()
        {
            Console.WriteLine("\n----- Замена перевода слова -----\n");
            Console.Write("Введите слово, перевод которого необходимо заменить: ");
            string word = Console.ReadLine();

            Console.WriteLine();
            _dictionary.SearchTranslation(word);
            Console.WriteLine();

            Console.Write("Введите перевод, который необходимо заменить: ");
            string oldTranslation = Console.ReadLine();
            Console.Write("Введите перевод, на который необходимо заменить: ");
            string newTranslation = Console.ReadLine();

            _dictionary.ChangeTranslation(word, oldTranslation, newTranslation);

            Console.Write("\nРезультат замены перевода: ");
            _dictionary.SearchTranslation(word);
            Console.WriteLine();
        }

        public void DeleteWordAction()
        {
            Console.WriteLine("\n----- Удаление слова -----");
            Console.Write("Введите слово, которое необходимо удалить: ");
            string word = Console.ReadLine();

            _dictionary.DeleteWord(word);

            Console.Write("\nРезультат удаления слова: ");
            _dictionary.SearchTranslation(word);
            Console.WriteLine();
        }

        public void DeleteTranslationAction()
        {
            Console.WriteLine("\n----- Удаление перевода слова -----");
            Console.Write("Введите слово, перевод которого необходимо удалить: ");
            string word = Console.ReadLine();

            Console.WriteLine();
            _dictionary.SearchTranslation(word);
            Console.WriteLine();

            Console.Write("Введите перевод, который необходимо удалить: ");
            string translation = Console.ReadLine();

            _dictionary.DeleteTranslation(word, translation);

            Console.Write("\nРезультат удаления перевода: ");
            _dictionary.SearchTranslation(word);
            Console.WriteLine();
        }

        public void SearchTranslationAction()
        {
            Console.WriteLine("\n----- Поиск перевода слова -----");
            Console.Write("Введите слово, перевод которого необходимо найти: ");
            string word = Console.ReadLine();

            Console.Write("\nРезультат поиска перевода: ");
            _dictionary.SearchTranslation(word);

            _writeToFile = new WriteToFile(@"D:\Результат.txt");
            _writeToFile.WriteResultToFile(_dictionary, word);
        }
    }
}