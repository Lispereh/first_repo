using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string str = Console.ReadLine();

            str = new string(ToCode(str.ToCharArray()));
            Console.WriteLine("Зашифрованная строка: " + str);

            str = new string(FromCode(str.ToCharArray()));
            Console.WriteLine("Расшифрованная строка: " + str);

            Console.ReadKey();
        }

        static char[] ToCode(char[] charArray)
        {
            for (int i = 0; i < charArray.Length; i++)
                charArray[i] = Convert.ToChar(charArray[i] + 3);

            return charArray;
        }

        static char[] FromCode(char[] charArray)
        {
            for (int i = 0; i < charArray.Length; i++)
                charArray[i] = Convert.ToChar(charArray[i] - 3);

            return charArray;
        }
    }
}