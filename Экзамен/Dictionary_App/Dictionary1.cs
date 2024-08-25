using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_1_Dictionary
{
    internal class Dictionary1
    {

        public string Name {  get; set; }
            // Тип словаря (например, англо-русский)

        private Dictionary<string, List<string>> _dictionary; // Словарь

        // Создание словаря
        public void CreateDictionary()
        {
            _dictionary = new Dictionary<string, List<string>>();
        }

        // Добавление слова и перевода в уже существующий словарь
        public void AddWord(string word, string definition)
        {
            // Если ключ ещё не существует, он создается с пустым списком
            if (!_dictionary.ContainsKey(word))
                _dictionary[word] = new List<string>();

            _dictionary[word].Add(definition);
        }

        // Замена слова в словаре
        public void ReplaceWord (string replacementWord, string newWord)
        {
            // Если ключ существует, происходит замена слова
            if (_dictionary.ContainsKey(replacementWord))
            {
                List<string> list = _dictionary[replacementWord];
                _dictionary.Remove(replacementWord);
                _dictionary.Add(newWord, list);
            }
                
            else
                Console.WriteLine($"Слово \"{replacementWord}\"" +
                                  $"не найдено в словаре");
        }

        public string PrintSameWordsToFile(string word)
        {
            if (_dictionary.TryGetValue(word, out List<string> values))
                return $"{word}: {string.Join(", ", values)}";

            else
                return "";
        }

        // Вывод слов с одинаковым ключом
        public bool PrintSameWords(string word)
        {
            // Проверка, существует ли ключ в словаре
            if (_dictionary.TryGetValue(word, out List<string> values))
            {
                // Выводим содержимое элемента на экран
                Console.WriteLine($"{word}: {string.Join(", ", values)}");
                return true;
            }
            else
            {
                Console.WriteLine($"Слово \"{word}\"" +
                                  $"не найдено в словаре");

                return false;
            }
        }

        // Замена значения в словаре
        public void ReplaceDefinition(string word, 
                                      string replacementDefinition,
                                      string newDefinition)
        {
            // Получение списка по ключу
            List<string> list = _dictionary[word];

            // Получение индекса элемента
            int index = list.IndexOf(replacementDefinition);

            // Замена значения
            list[index] = newDefinition;
        }

        // Выбор значения для замены
        public void ChooseDefinitionForReplace(string word) 
        {
            bool result = PrintSameWords(word);

            if (result)
            {
                Console.Write("Введите значение, которое необходимо заменить: ");
                string replacementDefinition = Console.ReadLine();

                Console.Write("Введите новое значение для замены: ");
                string newDefinition = Console.ReadLine();

                ReplaceDefinition(word, replacementDefinition, newDefinition);
            }
        }

        // Удаление слова
        public void DeleteWord(string word)
        {
            // Если ключ существует, происходит удаление слова
            if (_dictionary.ContainsKey(word))
                _dictionary.Remove(word);
            else
                Console.WriteLine($"Слово \"{word}\"" +
                                  $"не найдено в словаре");
        }

        // Удаление перевода
        public void DeleteDefinition(string word, string definition)
        {
            // Получение списка по ключу
            List<string> list = _dictionary[word];

            if (list.Count > 1)
                // Удаление значения
                list.Remove(definition);
            else
                Console.WriteLine("Невозможно удалить значение, т.к. " +
                                  "это последний перевод");

        }

        // Выбор перевода для удаления
        public void ChooseDefinitionForDelete(string word)
        {
            bool result = PrintSameWords(word);

            if (result)
            {
                Console.Write("Введите значение, которое необходимо удалить: ");
                string replacementDefinition = Console.ReadLine();

                DeleteDefinition(word, replacementDefinition);
            }
        }

        // Поиск перевода слова
        public void SearchDefinition(string word)
        {
            bool result = PrintSameWords(word);
        }

        public void PrintDictionary()
        {
            Console.WriteLine($"----- {Name} словарь -----");

            foreach (var word in _dictionary)
                Console.WriteLine($"{word.Key}: {string.Join(", ", word.Value)}");
        }
    }
}