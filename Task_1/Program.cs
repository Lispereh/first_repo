using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeA = 5;
            int[] A = new int[sizeA];

            int rows = 3;
            int columns = 4;
            int[,] B = new int[rows, columns];

            fillArrayKeyboard(A, sizeA);
            print1DArray(A);
            Console.WriteLine();

            fillArrayRandom(B, rows, columns);
            print2DArray(B);

            int minA = min1D(A);
            int minB = min2D(B);
            int totalMinimum = totalMin(minA, minB);

            Console.WriteLine("Общий минимум: " +  totalMinimum);

            int maxA = max1D(A);
            int maxB = max2D(B);
            int totalMaximum = totalMax(maxA, maxB);

            Console.WriteLine("Общий максимум: " + totalMaximum);

            int sumA = sum1D(A);
            int sumB = sum2D(B);
            int totalAmount = totalSum(sumA, sumB);

            Console.WriteLine("Общая сумма: " + totalAmount);

            long prodA = prod1D(A);
            long prodB = prod2D(B);
            long totalProduct = totalProd(prodA, prodB);

            Console.WriteLine("Общее произведение: " + totalProduct);

            int evenSumA = evenSum1D(A);
            Console.WriteLine("Сумма четных элементов массива А: " + evenSumA);

            int oddSumB = oddColumnsSum2D(B);
            Console.WriteLine("элементов нечётных столбцов массива B: " + oddSumB);

            Console.ReadKey();
        }

        // Заполнение одномерного массива числами, введёнными с клавиатуры
        static void fillArrayKeyboard(int[] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("Введите " + (i + 1) + "-й элемент массива: ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
        }

        // Заполнение двумерного массива рандомными числами
        static void fillArrayRandom(int[,] array, int rows, int columns)
        {

            Random random = new Random();

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    array[i, j] = random.Next(10, 20);
        }

        // Вывод на экран одномерного массива в одну строку
        static void print1DArray(int[] array)
        {
            Console.WriteLine("----- Массив A -----\n");

            foreach (int element in array)
                Console.Write(element + " ");

            Console.WriteLine("\n");
        }

        // Вывод на экран двумерного массива в виде матрицы
        static void print2DArray(int[,] array)
        {
            Console.WriteLine("----- Массив B -----\n");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + " ");

                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        // Поиск минимального элемента в одномерном массиве
        static int min1D (int[] array)
        {
            int min = int.MaxValue;

            for(int i = 0; i < array.GetLength(0); i++)
                min = (array[i] < min ? array[i] : min);

            return min;
        }

        // Поиск минимального элемента в двумерном массиве
        static int min2D(int[,] array)
        {
            int min = int.MaxValue;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    min = (array[i, j] < min ? array[i, j] : min);

            return min;
        }

        // Определение общего минимального элемента
        static int totalMin(int min1D, int min2D)
        {
            int totalMinimum = (min1D < min2D ? min1D : min2D);

            return totalMinimum;
        }

        // Поиск максимального элемента в одномерном массиве
        static int max1D(int[] array)
        {
            int max = int.MinValue;

            for (int i = 0; i < array.GetLength(0); i++)
                max = (array[i] > max ? array[i] : max);

            return max;
        }

        // Поиск максимального элемента в двумерном массиве
        static int max2D(int[,] array)
        {
            int max = int.MinValue;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    max = (array[i, j] > max ? array[i, j] : max);

            return max;
        }

        // Определение общего минимального элемента
        static int totalMax(int max1D, int max2D)
        {
            int totalMaximum = (max1D > max2D ? max1D : max2D);

            return totalMaximum;
        }

        // Сумма элементов одномерного массива
        static int sum1D(int[] array)
        {
            int sum = 0;

            foreach(int element in array)
                sum += element;

            return sum;
        }

        // Сумма элементов двумерного массива
        static int sum2D(int[,] array)
        {
            int sum = 0;

            foreach (int element in array)
                sum += element;

            return sum;
        }

        // Общая сумма
        static int totalSum(int sum1D, int sum2D)
        {
            return sum1D + sum2D;
        }

        // Произведение элементов одномерного массива
        static long prod1D(int[] array)
        {
            long prod = 1;

            foreach (int element in array)
                prod *= element;

            return prod;
        }

        // Произведение элементов двумерного массива
        static long prod2D(int[,] array)
        {
            long prod = 1;

            foreach (int element in array)
                prod *= element;

            return prod;
        }

        // Общее произведение
        static long totalProd(long prod1D, long prod2D)
        {
            return prod1D * prod2D;
        }

        // Сумма чётных элементов одномерного массива
        static int evenSum1D(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
                sum += (i % 2 == 0 ? array[i] : 0);

            return sum;
        }

        // Сумма элементов нечётных столбцов двумерного массива
        static int oddColumnsSum2D(int[,] array)
        {
            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    sum += (j % 2 != 0 ? array[i, j] : 0);

            return sum;
        }
    }
}