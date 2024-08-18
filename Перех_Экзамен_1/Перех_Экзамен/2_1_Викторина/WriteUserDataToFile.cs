using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_2_Quiz_App
{
    /// <summary>
    /// Итоговая запись в файл
    /// </summary>
    internal class WriteUserDataToFile
    {
        private string _path;

        public WriteUserDataToFile() : this("usersData.txt") { }

        public WriteUserDataToFile(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Запись в файл
        /// </summary>
        public void Writing(List<User> users)
        {
            try
            {
                if (users == null || users.Count == 0)
                {
                    Console.WriteLine("Не обнаружено пользователей для записи в файл");
                    return;
                }

                using (StreamWriter writer = new StreamWriter(_path))
                {
                    foreach (User user in users)
                    {
                        string line = $"{user.GetLogin()},{user.GetPassword()}," +
                                      $"{user.GetBirthDate():yyyy.MM.dd}," +
                                      $"{FormatLastResults(user.GetLastResults())}";
                        writer.WriteLine(line);
                    }
                }
                Console.WriteLine($"Данные успешно записаны в файл {_path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
            }
        }

        /// <summary>
        /// Форматирования списка результатов пройденных викторин в строку
        /// </summary>
        private string FormatLastResults(Dictionary<string, int> lastResults)
        {
            if (lastResults == null || lastResults.Count == 0)
                return string.Empty;

            List<string> formattedResults = new List<string>();

            foreach (var result in lastResults)
                formattedResults.Add($"{result.Key}-{result.Value}");

            return string.Join("-", formattedResults);
        }
    }
}