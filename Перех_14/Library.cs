using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_107
{
    internal class Library
    {
        private List<Book> Books {  get; set; }

        public Library() 
        {
            Books = new List<Book>();
        }

        // Добавление книги в библиотеки
        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        // Удаление книги из библиотеки
        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public void PrintAllBooks()
        {
            int counter = 1;

            foreach(Book book in Books)
            {
                Console.WriteLine($"{counter}. {book}");
                counter++;
            }
        }

        public Book GetBook(int index)
        {
            return Books[index];
        }

        public Book FindBookByTitle(string title)
        {
            foreach (Book book in Books)
                if (book.Title == title)
                    return book;

            return null;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> booksByAuthor = new List<Book>();

            foreach (Book book in Books)
                if (book.Author == author)
                    booksByAuthor.Add(book);

            return booksByAuthor;
        }

        public List<Book> GetBooksByYear(int year)
        {
            List<Book> booksByYear = new List<Book>();

            foreach (Book book in Books)
                if (book.Year == year)
                    booksByYear.Add(book);

            return booksByYear;
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            List<Book> booksByGenre = new List<Book>();

            foreach (Book book in Books)
                if (book.Genre == genre)
                    booksByGenre.Add(book);

            return booksByGenre;
        }
    }
}