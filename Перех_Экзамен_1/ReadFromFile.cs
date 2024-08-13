using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Task_Exam
{
    internal class ReadFromFile
    {
        private string _path;
        private Glossary _dictionary;

        public ReadFromFile(string path)
        {
            _path = path;
            _dictionary = new Glossary(); 
        }

        public Glossary Reading()
        {
            // Чтение файла построчно
            try
            {
                StreamReader reader = new StreamReader(_path);
                try
                {
                    // Название словаря = имя файла без расширения
                    _dictionary.Name = Path.GetFileNameWithoutExtension(_path);

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Разбиваем считанную строку на массив строк по разделителю ','
                        string[] arrayLine =
                                 line.Split(new char[] { ',' },
                                 StringSplitOptions.RemoveEmptyEntries);

                        // Если переводов слов больше 1, сохраняем их в список,
                        // а затем добавляем в словарь
                        if (arrayLine.Length > 2)
                        {
                            string word = arrayLine[0];
                            List<string> translation = new List<string>();

                            for (int i = 1; i < arrayLine.Length; i++)
                                translation.Add(arrayLine[i]);

                            _dictionary.AddInfoFromFile(word, translation);
                        }
                        else
                            _dictionary.AddWord(arrayLine[0], arrayLine[1]);
                    }
                    return _dictionary;
                }
                finally
                {
                    reader.Close(); // Закрытие файла
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при чтении файла: {ex.Message}");
                return null;
            }
        }
    }
}