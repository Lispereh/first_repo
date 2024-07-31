using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите предложение: ");
            string sentence = Console.ReadLine();

            char[] sentenceArray = sentence.ToCharArray();
            int pointIndex = 0;

            for(int i = 0; i < sentenceArray.Length; i++)
            {
                if(i == pointIndex && Char.IsLower(sentenceArray[i]))
                    sentenceArray[i] = Char.ToUpper(sentenceArray[i]);

                if (sentenceArray[i] == '.' && i < sentenceArray.Length - 1)
                    pointIndex = i + 2;
            }

            sentence = new string(sentenceArray);
            Console.WriteLine("Результат: " + sentence);

            Console.ReadKey();

        }
    }
}