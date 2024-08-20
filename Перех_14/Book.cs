using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_107
{
    internal class Book
    {
        public string Title { get; set; } // Название книги
        public string Author { get; set; } // Автор книги
        public int Year { get; set; } // Год издания
        public string Genre { get; set; } // Жанр книги

        public Book (string title, string author,
                     int year, string genre)
        {
            Title = title;
            Author = author;
            Year = year;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Author} - \"{Title}\" ({Year} г.)";
        }
    }
}