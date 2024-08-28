using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    // Отображение пунктов меню
    internal class Menu
    {
        // Меню для входа / регистрации
        public int SignInOrSignUpMenu()
        {
            Console.WriteLine("----- Меню -----\n");
            Console.WriteLine("1. Вход");
            Console.WriteLine("2. Регистрация\n");

            Console.Write("Введите код меню: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        // Основное меню
        public int MainMenu()
        {
            Console.WriteLine("----- Меню -----\n");
            Console.WriteLine("1. Смотреть результаты прошлых викторин");
            Console.WriteLine("2. Изменить настройки");
            Console.WriteLine("3. Стартовать викторину");
            Console.WriteLine("4. Смотреть ТОП-20 результатов викторины");
            Console.WriteLine("5. Выход\n");

            Console.Write("Введите код меню: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        // Меню для изменения данных
        public int ChangeMenu()
        {
            Console.WriteLine("----- Меню -----\n");
            Console.WriteLine("1. Изменить пароль");
            Console.WriteLine("2. Изменить дату рождения\n");

            Console.Write("Введите код меню: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        // Меню с темами викторин
        public int QuizesMenu()
        {
            Console.WriteLine("----- Меню викторин -----\n");
            Console.WriteLine("1. Тема: Основные понятия ООП");
            Console.WriteLine("2. Тема: Классы, структуры");
            Console.WriteLine("3. Тема: Коллекции");
            Console.WriteLine("4. Тема: Случайная викторина");
            Console.WriteLine("5. Выход\n");

            Console.Write("Введите код меню: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        // Меню с темами викторин для ТОП-20
        public int TopTwentyMenu()
        {
            Console.WriteLine("----- Меню викторин -----\n");
            Console.WriteLine("1. Тема: Основные понятия ООП");
            Console.WriteLine("2. Тема: Классы, структуры");
            Console.WriteLine("3. Тема: Коллекции\n");

            Console.Write("Введите код меню: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }
    }
}