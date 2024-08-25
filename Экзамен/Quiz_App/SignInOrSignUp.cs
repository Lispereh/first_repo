using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal class SignInOrSignUp
    {
        private List<User> _users;

        public SignInOrSignUp(List<User> users)
        {
            _users = users;
        }

        public List<User> GetUsers() => _users;

        // Вход в приложение
        public User SignIn(string login, string password)
        {
            char[] codePassword = password.ToCharArray();

            for(int i = 0; i < codePassword.Length; i++)
                codePassword[i] = Convert.ToChar(codePassword[i] + 3);

            password = new string(codePassword);

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
                Console.WriteLine("Пользователь не найден. Пожалуйста, зарегистрируйтесь.\n");
                return SignUp();
            }
        }

        // Регистрация в приложении
        public User SignUp()
        {
            Console.WriteLine("----- Регистрация -----\n");
            Console.Write("Укажите логин: ");
            string login = Console.ReadLine();

            // Проверка, существует ли пользователь с таким логином
            if (_users.Any(u => u.GetLogin() == login))
            {
                Console.Clear();
                Console.WriteLine("Пользователь с таким логином уже существует.");
                return null;
            }

            Console.Write("Укажите пароль: ");
            string password = Console.ReadLine();

            DateTime birthDate = InputBirthDate();

            // Создаем нового пользователя и добавляем его в список
            User newUser = new User(login, password, birthDate, new Dictionary<string, int>());
            _users.Add(newUser);

            Console.Clear();
            Console.WriteLine("Регистрация успешна!\n");
            return newUser;
        }

        // Ввод даты рождения
        public DateTime InputBirthDate()
        {
            int bDay, bMonth, bYear;

            // Проверка корректности ввода даты
            while (true)
            {
                Console.Write("Укажите день рождения (1-31): ");

                // TryParse - для корректности проверки ввода, возвращает true или false
                if (int.TryParse(Console.ReadLine(), out bDay) && bDay >= 1 && bDay <= 31)
                    break;
                Console.WriteLine("Некорректный ввод. Повторите попытку.\n");
            }

            while (true)
            {
                Console.Write("Укажите месяц рождения (1-12): ");

                // TryParse - для корректности проверки ввода, возвращает true или false
                if (int.TryParse(Console.ReadLine(), out bMonth) && bMonth >= 1 && bMonth <= 12)
                    break;
                Console.WriteLine("Некорректный ввод. Повторите попытку.\n");
            }

            while (true)
            {
                Console.Write("Укажите год рождения: ");

                // TryParse - для корректности проверки ввода, возвращает true или false
                if (int.TryParse(Console.ReadLine(), out bYear) && bYear > 1900 && bYear <= DateTime.Now.Year)
                    break;
                Console.WriteLine("Некорректный ввод. Повторите попытку.\n");
            }

            return new DateTime(bYear, bMonth, bDay);
        }
    }
}