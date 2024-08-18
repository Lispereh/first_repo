using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_2_Quiz_App
{
    /// <summary>
    /// Выполнение действий меню
    /// </summary>
    internal class PerformMenuActions
    {
        private Menu _menu;
        private User _user;
        private SignInOrSignUp _signInOrSignUp;
        private ReadQuizFromFile _readQuizFromFile;
        private Quiz _quiz;
        private QuizManager _quizManager;

        public PerformMenuActions()
        {
            _menu = new Menu();
        }

        /// <summary>
        /// Основная функция для работы программы
        /// </summary>
        public void WorkOfProgram()
        {
            SignInOrSignUp();

            int doContinue = 1;
            int codeMainMenu = 0;

            do
            {
                codeMainMenu = MainMenu();

                if (codeMainMenu == 4)
                {
                    Console.Clear();
                    WriteUserDataToFile writeUserDataToFile = new WriteUserDataToFile();
                    writeUserDataToFile.Writing(_signInOrSignUp.GetUsers());
                    return;
                }

                Console.WriteLine("Продолжить? 1 - Да, 2 - Выход");
                Console.Write("Введите код меню: ");
                doContinue = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if(doContinue < 1 || doContinue > 2)
                {
                    Console.WriteLine("\nВведён неверный код. Повторите попытку.");

                    Console.Clear();
                    Console.WriteLine("Продолжить? 1 - Да, 2 - Выход");
                    Console.Write("Введите код меню: ");
                    doContinue = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                }

                if (doContinue == 2)
                {
                    Console.Clear();
                    // Запись в файл
                    WriteUserDataToFile writeUserDataToFile = new WriteUserDataToFile();
                    writeUserDataToFile.Writing(_signInOrSignUp.GetUsers());
                    return;
                }

            } while (doContinue == 1);
        }

        /// <summary>
        /// Работа с меню входа и регистрации
        /// </summary>
        public void SignInOrSignUp()
        {
            int choice = 0;

            do
            {
                choice = _menu.SignInOrSignUpMenu();

                if (choice < 1 || choice > 2) // Исправлено
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
            } while (choice < 1 || choice > 2); // Исправлено

            Console.Clear();

            if (choice == 1)
                SignIn();
            else
            {
                List<User> users = ReadingUsersData();
                _signInOrSignUp = new SignInOrSignUp(users);
                _user = _signInOrSignUp.SignUp();
            }
        }

        /// <summary>
        /// Работа с основным меню
        /// </summary>
        /// <returns></returns>
        public int MainMenu()
        {
            int choice = 0;

            do
            {
                choice = _menu.MainMenu();

                if (choice < 1 || choice > 4)
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
                if (choice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Выход выполнен успешно.");
                }
            } while (choice < 1 || choice > 4);

            Console.Clear();

            if (choice == 1)
                ShowLastResultsUser();
            else if (choice == 2)
                ChangeMenu();
            else if (choice == 3)
                QuizesMenu();

            return choice;
        }

        /// <summary>
        /// Работа с меню викторин
        /// </summary>
        public void QuizesMenu()
        {
            int choice = 0;

            do
            {
                choice = _menu.QuizesMenu();

                if (choice < 1 || choice > 4) // Исправлено
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
                if (choice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Выход выполнен успешно.");
                    return;
                }
            } while (choice < 1 || choice > 4); // Исправлено

            Console.Clear();

            if(choice == 1)
                StartQuiz("Основные понятия ООП.txt");
            else if(choice == 2)
                StartQuiz("Классы, структуры.txt");
            else if(choice == 3)
                StartQuiz("Коллекции.txt");
        }

        /// <summary>
        /// Чтение викторины из файла и её запуск
        /// </summary>
        public void StartQuiz(string path)
        {
            _readQuizFromFile = new ReadQuizFromFile(path);
            _quiz = _readQuizFromFile.Reading();
            _quizManager = new QuizManager();
            _quizManager.PassQuiz(_quiz, _user);
        }

        /// <summary>
        /// Работа с меню для смены пароля / даты рождения
        /// </summary>
        public void ChangeMenu()
        {
            int choice = 0;

            do
            {
                choice = _menu.ChangeMenu();

                if (choice < 1 || choice > 2)
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
            } while (choice < 1 || choice > 2); // Исправлено

            if (choice == 1)
            {
                Console.Clear();
                ChangePassword();
            }
            else
            {
                Console.Clear();
                ChangeBirthDate();
            }
        }

        /// <summary>
        /// Смена пароля
        /// </summary>
        public void ChangePassword()
        {
            Console.WriteLine("----- Смена пароля -----\n");

            Console.Write("Укажите пароль: ");
            string password = Console.ReadLine();

            _user.ChangePassword(password);
            Console.WriteLine("Пароль успешно изменён\n");
        }

        /// <summary>
        /// Смена даты рождения
        /// </summary>
        public void ChangeBirthDate()
        {
            Console.WriteLine("----- Смена даты рождения -----\n");

            DateTime newBirthDate = _signInOrSignUp.InputBirthDate();
            _user.ChangeBirthDate(newBirthDate);

            Console.WriteLine("\nДата рождения успешно изменена\n");
        }

        /// <summary>
        /// Отображение результатов последних викторин
        /// </summary>
        public void ShowLastResultsUser()
        {
            if (_user == null)
            {
                Console.WriteLine("Пользователь не вошёл в систему. Пожалуйста, выполните вход.");
                return;
            }

            _user.ShowLastResults();
        }

        /// <summary>
        /// Считывание списка пользователей из файла
        /// </summary>
        public List<User> ReadingUsersData()
        {
            ReadUserDataFromFile readUserDataFromFile = new ReadUserDataFromFile();
            List<User> users = readUserDataFromFile.Reading();
            return users;
        }

        /// <summary>
        /// Вход и регистрация (если пользователь не найден)
        /// </summary>
        public void SignIn()
        {
            Console.WriteLine("----- Вход  -----\n");

            Console.Write("Укажите логин: ");
            string login = Console.ReadLine();

            Console.Write("Укажите пароль: ");
            string password = Console.ReadLine();

            List<User> users = ReadingUsersData();
            _signInOrSignUp = new SignInOrSignUp(users);

            _user = _signInOrSignUp.SignIn(login, password);

            if (_user == null)
                Console.WriteLine("Неверный логин или пароль.");
        }
    }
}