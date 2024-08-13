using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Task_Exam
{
    internal class WriteToFile
    {
        private string _path;

        public WriteToFile(string path)
        {
            _path = path;
        }

        public void WriteResultToFile(Glossary dictionary, string word)
        {
            // Экспорт слово и вариантов его перевода в отедльный файл результата
            try
            {
                StreamWriter writer = new StreamWriter(_path, true); // true для добавления в конец файла
                try
                {
                    writer.WriteLine(dictionary.WriteResultToFile(word));
                }
                finally
                {
                    writer.Close(); // Закрытие файла
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при записи в файл: {ex.Message}");
            }
        }
    }
}