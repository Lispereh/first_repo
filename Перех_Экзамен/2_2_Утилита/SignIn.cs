using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editing_Utility
{
    /// <summary>
    /// Вход в утилиту
    /// </summary>
    internal class SignIn
    {
        private List<User> _users;

        public SignIn() : this(new List<User>()) { }

        public SignIn(List<User> users)
        {
            _users = users;
        }

        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        public List<User> GetUsers()
        {
            return _users;
        }

        /// <summary>
        /// Вход в утилиту
        /// </summary>
        public User UserSignIn(string login, string password)
        {
            // Поиск пользователя с указанными логином и паролем
            User user = _users.FirstOrDefault(u => u.GetLogin() == login && u.GetPassword() == password);

            if (user != null)
            {
                Console.Clear();
                Console.WriteLine("Успешный вход!\n");
                return user;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Пользователь не найден.\n");
                return null;
            }
        }
    }
}