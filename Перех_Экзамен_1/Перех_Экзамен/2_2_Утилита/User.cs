using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editing_Utility
{
    /// <summary>
    /// Данные пользователя
    /// </summary>
    internal class User
    {
        private string _login;
        private string _password;

        public User() : this(null, null) { }

        public User(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public string GetLogin()
        {
            return _login;
        }

        public string GetPassword()
        {
            return _password;
        }
    }
}