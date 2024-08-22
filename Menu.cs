using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_2_Quiz_App
{
    /// <summary>
    /// Отображение пунктов меню
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Меню для входа / регистрации
        /// </summary>
        /// <returns></returns>
        public int SignInOrSignUpMenu()
        {
            Console.WriteLine("----- Меню -----\n");
            Console.WriteLine("1. Вход");
            Console.WriteLine("2. Регистрация\n");

            Console.Write("Введите код меню: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        /// <summary>
        /// Основное меню
        /// </summary>
        /// <returns></returns>
        public int MainMenu()
        {
            Console.WriteLine("----- Меню -----\n");
            Console.WriteLine("1. Смотреть результаты прошлых викторин");
            Console.WriteLine("2. Изменить настройки");
            Console.WriteLine("3. Стартовать викторину");
            Console.WriteLine("4. Выход\n");

            Console.Write("Введите код меню: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        /// <summary>
        /// Меню для изменения данных
        /// </summary>
        /// <returns></returns>
        public int ChangeMenu()
        {
            Console.WriteLine("----- Меню -----\n");
            Console.WriteLine("1. Изменить пароль");
            Console.WriteLine("2. Изменить дату рождения\n");

            Console.Write("Введите код меню: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        /// <summary>
        /// Меню с темами викторин
        /// </summary>
        /// <returns></returns>
        public int QuizesMenu()
        {
            Console.WriteLine("----- Меню викторин -----\n");
            Console.WriteLine("1. Тема: Основные понятия ООП");
            Console.WriteLine("2. Тема: Классы, структуры");
            Console.WriteLine("3. Тема: Коллекции");
            Console.WriteLine("4. Выход\n");

            Console.Write("Введите код меню: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }
    }
}