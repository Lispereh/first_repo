using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = GetInput();
            double result = CalculateExpression(input);
            DisplayResult(result);
            Console.ReadKey();
        }

        // Функция для получения пользовательского ввода.
        static string GetInput()
        {
            Console.Write("Введите арифметическое выражение (используйте только + и -): ");
            return Console.ReadLine();
        }

        // Основная логика вычисления выражения
        static double CalculateExpression(string input)
        {
            double total = 0;
            double currentNumber = 0;
            char operation = '+';
            int length = input.Length;

            for (int i = 0; i < length; i++)
            {
                char c = input[i];

                // Если символ - цифра или точка, считываем число
                if (char.IsDigit(c) || c == '.')
                {
                    string numberStr = ReadNumber(input, ref i); // ref - передача по ссылке
                    currentNumber = double.Parse(numberStr);
                }

                // Если символ - операция, обрабатываем предыдущее число
                if (i < length && (c == '+' || c == '-'))
                {
                    total = UpdateTotal(total, currentNumber, operation);
                    operation = c;
                }
            }

            // Обрабатываем последнее число
            total = UpdateTotal(total, currentNumber, operation);

            return total;
        }

        // Функция для считывания числа из строки
        static string ReadNumber(string input, ref int index) // ref - передача по ссылке
        {
            string numberStr = string.Empty;
            int length = input.Length;

            // Считываем все цифры и точку, если есть
            while (index < length && (char.IsDigit(input[index]) || input[index] == '.'))
            {
                numberStr += input[index];
                index++;
            }

            index--; // Уменьшаем индекс, т.к. он будет увеличен в конце цикла
            return numberStr;
        }

        // Функция для обновления общего результата
        static double UpdateTotal(double total, double currentNumber, char operation)
        {
            if (operation == '+')
                return total + currentNumber;
            else if (operation == '-')
                return total - currentNumber;

            return total;
        }

        // Функция для отображения результата
        static void DisplayResult(double result)
        {
            Console.WriteLine($"Результат: {result}");
        }
    }
}