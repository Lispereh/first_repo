using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int rows = 5;
            int cols = 5;

            int[,] matrix = new int[rows, cols];

            fillArrayRandom(matrix);
            print2DArray(matrix);

            min2D(matrix);
            max2D(matrix);

            int maxInMatrix = max2D(matrix);
            int minInMatrix = min2D(matrix);

            definingBoundaries();
            Console.WriteLine("----- ----- ----- -----\n");

            Console.WriteLine("Минимальный элемент: " + minInMatrix);
            Console.WriteLine("Строка: " + minIndexI);
            Console.WriteLine("Столбец: " + minIndexJ + "\n");


            Console.WriteLine("Максимальный элемент: " + maxInMatrix);
            Console.WriteLine("Строка: " + maxIndexI);
            Console.WriteLine("Столбец: " + maxIndexJ + "\n");

            Console.WriteLine("----- ----- ----- -----\n");

            int totalSum = sum(matrix);
            Console.WriteLine("Сумма = " + totalSum);

            Console.ReadKey();
        }

        // Заполнение двумерного массива рандомными числами в диапазоне от –100 до 100
        static void fillArrayRandom(int[,] array)
        {

            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = random.Next(-100, 100);
        }

        // Вывод на экран двумерного массива
        static void print2DArray(int[,] array)
        {
            Console.WriteLine("----- Матрица -----\n");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    // Форматированный вывод для выравнивания
                    Console.Write($"{array[i, j],4} "); // 4 - ширина поля для выравнивания

                Console.WriteLine();
            }

            Console.WriteLine("\n");
        }

        // Глобальные переменные
        static int minIndexI = -1, minIndexJ = -1;

        // Поиск минимального элемента
        static int min2D(int[,] array)
        {
            int min = int.MaxValue;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {

                    if(array[i, j] < min)
                    {
                        min = array[i, j];
                        minIndexI = i;
                        minIndexJ = j;
                    }
                }

            return min;
        }

        // Глобальные переменные
        static int maxIndexI = -1, maxIndexJ = -1;

        // Поиск максимального элемента
        static int max2D(int[,] array)
        {
            int max = int.MinValue;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {

                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        maxIndexI = i;
                        maxIndexJ = j;
                    }
                }

            return max;
        }

        // Глобальные переменные
        static int iStart, iEnd;
        static int jStart, jEnd;

        // Определение границ для суммы
        static void definingBoundaries()
        {

            if(minIndexI < maxIndexI)
            {
                iStart = minIndexI;
                iEnd = maxIndexI;
                jStart = minIndexJ;
                jEnd = maxIndexJ;
            }
            else if(minIndexI > maxIndexI)
            {
                iStart = maxIndexI;
                iEnd = minIndexI;
                jStart = maxIndexJ;
                jEnd = minIndexJ;
            }
            else
            {
                iStart = minIndexI;
                iEnd = maxIndexI;

                if (minIndexJ < maxIndexJ)
                {
                    jStart = minIndexJ;
                    jEnd = maxIndexJ;
                }
                else
                {
                    jStart = maxIndexJ;
                    jEnd = minIndexJ;
                }
            }
        }

        static int sum(int[,] array)
        {
            int sum = 0;

            for(int i = iStart; i <= iEnd; i++)
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == iEnd && j >= jEnd)
                        break;
                    else if (i == iStart && j <= jStart)
                        continue;
                    else
                        sum += array[i, j];
                }

            return sum;
        }

    }
}