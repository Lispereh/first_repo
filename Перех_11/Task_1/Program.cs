using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_10;

namespace Task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Word> words = new List<Word>();

            words.Add(new Word("Hello", "привет"));
            words.Add(new Word("Cat", "кошка"));
            words.Add(new Word("Dog", "собака"));

            words.Sort();
            Dec dec = new Dec(words);

            foreach(var word in dec)
                Console.WriteLine(word);

            Console.ReadKey();
        }
    }
}