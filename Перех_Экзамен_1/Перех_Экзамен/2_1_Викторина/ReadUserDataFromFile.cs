using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_2_Quiz_App
{
    /// <summary>
    /// Чтение данных пользователей из файла
    /// </summary>
    internal class ReadUserDataFromFile
    {
        private string _path;

        public ReadUserDataFromFile() : this("usersData.txt") { }

        public ReadUserDataFromFile(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Чтение из файла
        /// </summary>
        public List<User> Reading()
        {
            List<User> users = new List<User>();

            try
            {
                string[] lines = File.ReadAllLines(_path);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 4)
                    {
                        string login = parts[0].Trim();
                        string password = parts[1].Trim();

                        string[] bDate = parts[2].Split('.');
                        int bYear = Convert.ToInt32(bDate[0]);
                        int bMonth = Convert.ToInt32(bDate[1]);
                        int bDay = Convert.ToInt32(bDate[2]);
                        DateTime birthDate = new DateTime(bYear, bMonth, bDay);

                        Dictionary<string, int> lastResults = ParseLastResults(parts[3].Trim());
                        users.Add(new User(login, password, birthDate, lastResults));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
            }

            return users;
        }

        /// <summary>
        /// Преобразование строки результатов викторин в Dictionary<string, int>
        /// </summary>
        public Dictionary<string, int> ParseLastResults(string results)
        {
            Dictionary<string, int> lastResults = new Dictionary<string, int>();

            string[] parts = results.Split('-');

            if (parts.Length % 2 == 0)
                for (int i = 0; i < parts.Length; i += 2)
                {
                    string subject = parts[i];
                    int score = int.Parse(parts[i + 1]);
                    lastResults[subject] = score;
                }

            return lastResults;
        }
    }
}