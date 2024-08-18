using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editing_Utility
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
                    string login = parts[0].Trim();
                    string password = parts[1].Trim();
                    users.Add(new User(login, password));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
            }

            return users;
        }
    }
}