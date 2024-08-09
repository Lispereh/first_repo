using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listOfBooks
{
    internal class ListOfBooksToRead
    {

        private Book[] _books;

        public ListOfBooksToRead(int size)
        {
            _books = new Book[size];
        }

        public ListOfBooksToRead(Book[] newBooks)
        {
            _books = newBooks;
        }

        public int Length
        {
            get { return _books.Length; }
        }

        public int this[string name]
        {
            get
            {
                for (int i = 0; i < _books.Length; i++)
                {
                    if (name == _books[i].Name)
                    {
                        return i;
                    }
                }
                return -1;
            }

        }

        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < _books.Length)
                {
                    return _books[index];
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < _books.Length)
                {
                    _books[index] = value;
                    return;
                }

                throw new IndexOutOfRangeException();
            }
        }

        public static ListOfBooksToRead operator +(ListOfBooksToRead booksList, Book book)
        {
            Book[] newBooks = new Book[booksList._books.Length + 1];

            for (int i = 0; i < booksList._books.Length; i++)
                newBooks[i] = booksList._books[i];

            newBooks[newBooks.Length - 1] = book;

            return new ListOfBooksToRead(newBooks);
        }

        public static ListOfBooksToRead operator -(ListOfBooksToRead booksList, int index)
        {
            Book[] newBooks = new Book[booksList._books.Length - 1];

            for (int i = 0; i < booksList._books.Length; i++)
            {
                if (i == index)
                    continue;

                if (i < index)
                    newBooks[i] = booksList._books[i];
                else if(i > index)
                    newBooks[i - 1] = booksList._books[i];
            }

            return new ListOfBooksToRead(newBooks);
        }

        public void printBooks()
        {
            int index = 1;
            foreach(Book book in _books)
            {
                Console.WriteLine($"{index}. {book.ToString()}");
                index++;
            }
        }
    }
}