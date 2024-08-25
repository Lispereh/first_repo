using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_1_Dictionary
{
    internal class FileWriting
    {

        public void WriteDictionaryToFile(Dictionary<string, List<string>> dictionary,
                                          string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (var word in dictionary)
                    {
                        // Форматирование строки для записи
                        string line = $"{word.Key}: {string.Join(", ", word.Value)}";
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public void WriteResultToFile(string result, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}