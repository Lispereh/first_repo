using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exam_Task_1_Dictionary
{
    internal class FileReading
    {
        private FileInfo _file;
        private string _path;
        private Dictionary1 _dictionary;

        public FileReading(string path)
        {
            _path = path;
        }

        public Dictionary1 ReadFromFile()
        {
            try
            {
                // Открытие файла и чтение построчно
                using (StreamReader sr = new StreamReader(_path))
                {
                    _file = new FileInfo(_path);
                    _dictionary = new Dictionary1 
                    { 
                        Name = _file.Name.Substring(0, _file.Name.Length - 4) // Название словаря - название файла без расширения
                    };
                    _dictionary.CreateDictionary();

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] arrayLine = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        
                        if (arrayLine.Length > 2)
                            for(int i = 1; i < arrayLine.Length; i++)
                                _dictionary.AddWord(arrayLine[0], arrayLine[i]);
                        else
                            _dictionary.AddWord(arrayLine[0], arrayLine[1]);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден. Проверьте путь к файлу.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            return _dictionary;
        }
    }
}