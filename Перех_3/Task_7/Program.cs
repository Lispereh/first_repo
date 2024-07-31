using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string text = "To be, or not to be, that is the question,\n" +
                          "Whether 'tis nobler in the mind to suffer\n" +
                          "The slings and arrows of outrageous fortune,\n" +
                          "Or to take arms against a sea of troubles,\n" +
                          "And by opposing end them? To die: to sleep;\n" +
                          "No more; and by a sleep to say we end\n" +
                          "The heart-ache and the thousand natural shocks\n" +
                          "That flesh is heir to, 'tis a consummation\n" +
                          "Devoutly to be wish'd. To die, to sleep";

            Console.WriteLine("Исходный текст\n\n" + text + "\n\n");

            string word = "die";

            // Подсчитываем количество вхождений слова "die"
            // вычитаем 1, т.к. количество частей на единицу больше, чем количество вхождений слова
            int count = text.Split(new[] { word }, StringSplitOptions.None).Length - 1;

            text = text.Replace(word, "***");
            Console.WriteLine("Текст после замены\n\n" + text + "\n\n");
            Console.WriteLine($"Количество замен слова { word } = { count }");

            Console.ReadKey();
        }
    }
}