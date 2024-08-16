using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    internal class Word : IComparable<Word>
    {
        private string _word;
        private string _translation;

        public Word() : this(null, null) { }

        public Word(string word, string translation)
        {
            _word = word;
            _translation = translation;
        }

        public int CompareTo(Word other)
        {
            return string.Compare(this._word, other._word);
        }

        public override string ToString()
        {
            return $"{_word} - {_translation}";
        }
    }
}