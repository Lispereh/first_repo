using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_1_Dictionary
{
    internal class WorkWithDictionary
    {
        private Dictionary1 _dictionary;
        private FileReading _readingFile;
        private FileWriting _writingFile;

        public void CreateDictionary(string name)
        {
            _dictionary = new Dictionary1 { Name = name };
            _dictionary.CreateDictionary();
        }

        public void OpenDictionary(string path)
        {
            _readingFile = new FileReading(path);
            _dictionary = _readingFile.ReadFromFile();
        }

        public void AddResultToFile(string result)
        {
            _writingFile = new FileWriting();
            _writingFile.WriteResultToFile(result, "D:\\Результат.txt");
        }

        public void AddValue()
        {
            Console.WriteLine("----- Добавление в словарь -----");

            Console.Write("Введите слово: ");
            string word = Console.ReadLine();

            Console.Write("Введите перевод: ");
            string definition = Console.ReadLine();

            _dictionary.AddWord(word, definition);

            Console.WriteLine("\n----- Результат добавления -----");
            _dictionary.PrintSameWords(word);
        }

        public void ChangeWord()
        {
            Console.WriteLine("\n----- Замена слова -----");

            Console.Write("Введите слово, которое необходимо заменить: ");
            string replacementWord = Console.ReadLine();

            Console.Write("Введите слово, на которое необходимо заменить: ");
            string newWord = Console.ReadLine();

            _dictionary.ReplaceWord(replacementWord, newWord);
            Console.WriteLine("\n----- Результат добавления -----");
            _dictionary.PrintSameWords(newWord);
        }

        public void ChangeDefinition()
        {
            Console.WriteLine("\n----- Замена значения -----");

            Console.Write("Введите слово, значение которого необходимо заменить: ");
            string word = Console.ReadLine();

            _dictionary.ChooseDefinitionForReplace(word);

            Console.WriteLine("\n----- Результат замены значения -----");
            _dictionary.PrintSameWords(word);
        }

        public void RemoveWord()
        {
            Console.WriteLine("\n----- Удаление слова -----");

            Console.Write("Введите слово, значение которого необходимо удалить: ");
            string word = Console.ReadLine();

            _dictionary.DeleteWord(word);

            Console.WriteLine("\n----- Результат удаления слова -----");
            _dictionary.PrintSameWords(word);
        }

        public void RemoveDefinition()
        {
            Console.WriteLine("\n----- Удаление перевода -----");

            Console.Write("Введите слово, значение которого необходимо удалить: ");
            string word = Console.ReadLine();

            _dictionary.ChooseDefinitionForDelete(word);

            Console.WriteLine("\n----- Результат удаления перевода -----");
            _dictionary.PrintSameWords(word);
        }

        public void SearchForDefinition()
        {
            Console.WriteLine("\n----- Поиск перевода -----");

            Console.Write("Введите слово, значение которого необходимо найти: ");
            string word = Console.ReadLine();

            _dictionary.PrintSameWords(word);
            AddResultToFile(_dictionary.PrintSameWordsToFile(word));
        }
    }
}