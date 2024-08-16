using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    internal class Dec : IEnumerable<Word>
    {
        private List<Word> _words;

        public Dec() : this(new List<Word>()) { }

        public Dec(List<Word> words)
        {
            _words = words;
        }

        public IEnumerator<Word> GetEnumerator()
        {
            return _words.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() // Реализация не обобщенного интерфейса
        {
            return GetEnumerator();
        }
    }
}