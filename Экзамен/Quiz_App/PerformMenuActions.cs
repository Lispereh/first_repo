using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal class PerformMenuActions
    {
        private Menu _menu;
        private User _user;
        private SignInOrSignUp _signInOrSignUp;

        public PerformMenuActions()
        {
            _menu = new Menu();
        }


        // Основная функция для работы программы
        public void WorkOfProgram()
        {
            SignInOrSignUp();

            int doContinue = 1;
            int codeMainMenu = 0;

            do
            {
                codeMainMenu = MainMenu();

                if (codeMainMenu == 5)
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

                if (doContinue < 1 || doContinue > 2)
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

        // Работа с основным меню
        public int MainMenu()
        {
            int choice = 0;

            do
            {
                choice = _menu.MainMenu();

                if (choice < 1 || choice > 5)
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
                if (choice == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Выход выполнен успешно.");
                }
            } while (choice < 1 || choice > 5);

            Console.Clear();

            if (choice == 1)
                ShowLastResultsUser();
            else if (choice == 2)
                ChangeMenu();
            else if (choice == 3)
                QuizesMenu();
            else if (choice == 4)
                TopTwentyUsersMenu();

            return choice;
        }

        // ТОП-20
        public void TopTwentyUsersMenu()
        {
            int choice = 0;

            do
            {
                choice = _menu.TopTwentyMenu();

                if (choice < 1 || choice > 3)
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
            } while (choice < 1 || choice > 3);

            if (choice == 1)
                ShowTopTwentyUsers("Основные понятия ООП");
            else if (choice == 2)
                ShowTopTwentyUsers("Классы, структуры");
            else if (choice == 3)
                ShowTopTwentyUsers("Коллекции");
        }

        public void ShowTopTwentyUsers(string quizName)
        {
            ShowTopTwenty showTopTwenty = new ShowTopTwenty();
            showTopTwenty.TopTwenty(_signInOrSignUp.GetUsers(), quizName);
        }

        // Работа с меню викторин
        public void QuizesMenu()
        {
            int choice = 0;

            do
            {
                choice = _menu.QuizesMenu();

                if (choice < 1 || choice > 5)
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
                if (choice == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Выход выполнен успешно.");
                    return;
                }
            } while (choice < 1 || choice > 5);

            Console.Clear();
            
            if (choice == 4)
            {
                Random random = new Random();
                choice = random.Next(1, 4);
            }

            ChoiceQuizTopic(choice);
        }

        // Выбор темы викторины
        public void ChoiceQuizTopic(int choice)
        {
            if (choice == 1)
                StartQuiz("Основные понятия ООП.txt");
            else if (choice == 2)
                StartQuiz("Классы, структуры.txt");
            else if (choice == 3)
                StartQuiz("Коллекции.txt");
        }

        // Чтение викторины из файла и её запуск
        public void StartQuiz(string path)
        {
            ReadQuizFromFile readQuizFromFile = new ReadQuizFromFile(path);
            QuizManager quizManager = readQuizFromFile.Reading();
            quizManager.PassQuiz(_user, _signInOrSignUp.GetUsers());
        }

        // Работа с меню для смены пароля / даты рождения
        public void ChangeMenu()
        {
            int choice = 0;

            do
            {
                choice = _menu.ChangeMenu();

                if (choice < 1 || choice > 2)
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
            } while (choice < 1 || choice > 2);

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

        // Смена пароля
        public void ChangePassword()
        {
            string password = "";
            bool check = false;

            do
            {
                Console.WriteLine("----- Смена пароля -----\n");
                Console.Write("Укажите пароль: ");

                password = ChangeSymbols(password);

                Console.Write("\nПовторите пароль: ");
                string checkpassword = "";

                checkpassword = ChangeSymbols(checkpassword);

                if (password == checkpassword)
                    check = true;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введённые пароли не совпадают. Повторите попытку\n");
                }

            } while (check == false);

            password = CodePassword(password);
            _user.ChangePassword(password);
            Console.WriteLine("\n\nПароль успешно изменён\n");
        }

        public string CodePassword(string password)
        {
            char[] codePassword = password.ToCharArray();

            for (int i = 0; i < codePassword.Length; i++)
                codePassword[i] = Convert.ToChar(codePassword[i] + 3);

            return new string(codePassword);
        }

        public string ChangeSymbols(string password)
        {
            while (true)
            {
                // Получаем один символ от пользователя
                var keyInfo = Console.ReadKey(intercept: true);

                // Если пользователь нажал Enter, выходим из цикла
                if (keyInfo.Key == ConsoleKey.Enter)
                    break;

                // Добавляем введенный символ в строку
                password += keyInfo.KeyChar;

                // Выводим звездочку вместо введенного символа
                Console.Write("*");
            }

            return password;
        }

        // Смена даты рождения
        public void ChangeBirthDate()
        {
            Console.WriteLine("----- Смена даты рождения -----\n");

            DateTime newBirthDate = InputBirthDate();
            _user.ChangeBirthDate(newBirthDate);

            Console.WriteLine("\nДата рождения успешно изменена\n");
        }

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

        // Отображение результатов последних викторин
        public void ShowLastResultsUser()
        {
            if (_user == null)
            {
                Console.WriteLine("Пользователь не вошёл в систему. Пожалуйста, выполните вход.");
                return;
            }

            _user.ShowLastResults();
        }

        // Работа с меню входа и регистрации
        public void SignInOrSignUp()
        {
            int choice = 0;

            do
            {
                choice = _menu.SignInOrSignUpMenu();

                if (choice < 1 || choice > 2)
                    Console.WriteLine("Введён неверный код меню. Повторите попытку.\n");
            } while (choice < 1 || choice > 2);

            Console.Clear();

            if (choice == 1)
                SignIn();
            else
            {
                ReadUserDataFromFile readUserDataFromFile = new ReadUserDataFromFile();
                List<User> users = readUserDataFromFile.Reading();
                _signInOrSignUp = new SignInOrSignUp(users);
                _user = _signInOrSignUp.SignUp();
            }
        }

        // Вход и регистрация (если пользователь не найден)
        public void SignIn()
        {
            Console.WriteLine("----- Вход  -----\n");

            Console.Write("Укажите логин: ");
            string login = Console.ReadLine();

            Console.Write("Укажите пароль: ");
            string password = "";

            password = ChangeSymbols(password);

            ReadUserDataFromFile readUserDataFromFile = new ReadUserDataFromFile();
            List<User> users = readUserDataFromFile.Reading();
            _signInOrSignUp = new SignInOrSignUp(users);

            _user = _signInOrSignUp.SignIn(login, password);
        }
    }
}