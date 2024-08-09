using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listOfBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ListOfBooksToRead books = new ListOfBooksToRead(3);

            books[0] = new Book { Name = "Улисс", 
                                  Author = "Джеймс Дж.", 
                                  PagesNumber = 1056 };

            books[1] = new Book { Name = "Война и мир", 
                                  Author = "Толстой Л.", 
                                  PagesNumber = 1360 };

            books[2] = new Book { Name = "Квинканкс", 
                                  Author = "Палиссер Ч.", 
                                  PagesNumber = 1472 };

            Console.WriteLine("----- Список книг -----\n");
            books.printBooks();

            Book book = new Book { Name = "Человек без свойств", 
                                   Author = "Музиль Р.", 
                                   PagesNumber = 1774 };

            books = books + book;

            Console.WriteLine("\n\n----- Добавление книги в список книг -----\n");
            books.printBooks();
            
            books = books - 2;

            Console.WriteLine("\n\n----- Удаление книги под номером 3 из списка книг -----\n");
            books.printBooks();

            Console.WriteLine("\n\n----- Книга под номером 2 -----");
            Console.WriteLine(books[1]);

            Console.WriteLine("\n\n----- Книга под названием \"Квинканкс\" -----");
            if(books["Квинканкс"] == -1)
                Console.WriteLine("Не найдено");
            else
                Console.WriteLine(books["Квинканкс"]);

            Console.WriteLine("\n\n----- Книга под названием \"Человек без свойств\" -----");
            if (books["Человек без свойств"] == -1)
                Console.WriteLine("Не найдено");
            else
                Console.WriteLine(books[books["Человек без свойств"]]);

            Console.ReadKey();
        }
    }
}