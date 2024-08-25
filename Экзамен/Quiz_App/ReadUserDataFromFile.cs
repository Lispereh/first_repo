﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal class ReadUserDataFromFile
    {
        private string _path;

        public ReadUserDataFromFile() : this("usersData.txt") { }

        public ReadUserDataFromFile(string path)
        {
            _path = path;
        }

        // Чтение данных из файла
        public List<User> Reading()
        {
            try
            {
                List<User> users = new List<User>();

                using (StreamReader reader = new StreamReader(_path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
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

                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
            }

            return null;
        }

        // Преобразование строки результатов викторин в Dictionary<string, int>
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