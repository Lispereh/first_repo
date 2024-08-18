using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Task_Exam
{
    internal class Glossary
    {
        public string Name {  get; set; } // Тип словаря (например, англо-русский)

        private Dictionary<string, List<string>> _dictionary; // Словарь

        public Glossary() : this("Безымянный словарь") { }

        public Glossary(string name)
        {
            Name = name;
            _dictionary = new Dictionary<string, List<string>>();
        }

        public void AddInfoFromFile(string word, List<string> translation)
        {
            _dictionary[word] = translation;
        }

        public string WriteResultToFile(string word)
        {
            // Проверка наличия слова в словаре
            if (_dictionary.ContainsKey(word))
            {
                List<string> translations = _dictionary[word];
                return $"{word} - {string.Join(", ", translations)}";
            }
            else
                return $"Произошла ошибка. " +
                       $"Слово \"{word}\" не найдено в словаре.";
        }

        // Добавление слова и его перевода
        public void AddWord(string word, string translation)
        {
            // Если слова нет в словаре, то создаём пустой список
            if(!_dictionary.ContainsKey(word) )
                _dictionary[word] = new List<string>();

            // Добавление перевода к слову
            _dictionary[word].Add(translation);
        }

        // Поиск перевода слова и его вывод на экран
        public void SearchTranslation(string word)
        {
            // Проверка наличия слова в словаре
            if (_dictionary.ContainsKey(word))
            {
                List<string> translations = _dictionary[word];
                Console.WriteLine($"{word} - {string.Join(", ", translations)}");
            }
            else
                Console.WriteLine($"Произошла ошибка. " +
                                  $"Слово \"{word}\" не найдено в словаре.");
        }

        // Замена слова в словаре
        public void ChangeWord(string oldWord, string newWord)
        {
            // Проверка наличия слова в словаре
            if (_dictionary.ContainsKey(oldWord))
            {
                List<string> translations = _dictionary[oldWord];
                _dictionary.Remove(oldWord); // Удаление элемента из словаря
                _dictionary.Add(newWord, translations); // Замена слова в словаре с сохранением перевода
            }
            else
                Console.WriteLine($"Произошла ошибка. " +
                                  $"Слово \"{oldWord}\" не найдено в словаре.");
        }

        // Замена перевода слова в словаре
        public void ChangeTranslation(string word,
                                      string oldTranslation,
                                      string newTranslation)
        {
            // Проверка наличия слова в словаре
            if (_dictionary.ContainsKey(word))
            {
                List<string> translations = _dictionary[word];

                // Проверка наличия перевода в списке переводов
                if (translations.Contains(oldTranslation))
                {
                    int index = translations.IndexOf(oldTranslation);
                    translations[index] = newTranslation; // Замена старого перевода на новый
                }
                else
                    Console.WriteLine($"Произошла ошибка. " +
                                      $"Перевод \"{oldTranslation}\" " +
                                      $"не найден для слова \"{word}\".");
            }
            else
                Console.WriteLine($"Произошла ошибка. " +
                                  $"Слово \"{word}\" не найдено в словаре.");
        }

        // Удаление слова
        public void DeleteWord(string word)
        {
            if (_dictionary.ContainsKey(word))
                _dictionary.Remove(word);
            else
                Console.WriteLine($"Произошла ошибка. " +
                                  $"Слово \"{word}\" не найдено в словаре.");
        }

        // Удаление перевода слова
        public void DeleteTranslation(string word, string translation)
        {
            if (_dictionary.ContainsKey(word))
            {
                List<string> translations = _dictionary[word];

                // Проверка наличия перевода в списке переводов
                if (translations.Contains(translation) && (translations.Count() > 1))
                    translations.Remove(translation);
                else
                    Console.WriteLine($"Произошла ошибка. " +
                                      $"Перевод \"{translation}\" " +
                                      $"невозможно удалить.");
            }
            else
                Console.WriteLine($"Произошла ошибка. " +
                                  $"Слово \"{word}\" не найдено в словаре.");
        }
    }
}