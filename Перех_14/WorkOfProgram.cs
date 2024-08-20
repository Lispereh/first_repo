using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_107
{
    internal class WorkOfProgram
    {
        private Library _library;

        public WorkOfProgram()
        {
            _library = new Library();
        }

        public void ProgramWorks()
        {
            CreateLibrary();
            FindBookByTitle();
            FindBooksByAuthor();
            FindBooksByYear();
            FindBooksByGenre();
            PrintAllBooks();
            DeleteBook();
            AddBook();
        }

        public void CreateLibrary()
        {
            _library.AddBook(new Book("Война и мир", "Л. Н. Толстой", 1863, "Роман"));
            _library.AddBook(new Book("451 градус по Фаренгейту", "Р. Брэдбери", 1953, "Философский роман"));
            _library.AddBook(new Book("Убить пересмешника", "Х. Ли", 1960, "Роман"));
            _library.AddBook(new Book("Конец детства", "А. Ч. Кларк", 1953, "Фантастика"));
            _library.AddBook(new Book("Рассказ Служанки", "М. Этвуд", 1985, "Роман"));
            _library.AddBook(new Book("Корни", "А. Хейли", 1976, "Роман"));
            _library.AddBook(new Book("Окончательный диагноз", "А. Хейли", 1959, "Роман"));
            _library.AddBook(new Book("Над пропастью во ржи", "Д. Д. Сэлинджер", 1951, "Роман"));
            _library.AddBook(new Book("Слабак", "Д. Уэллс", 1873, "Биография"));
            _library.AddBook(new Book("Субмарина", "Д. Данторн", 2019, "История в стиле подросткового дневника"));
        }

        public void FindBookByTitle()
        {
            Console.WriteLine("----- Поиск книги по названию -----\n");

            Console.Write("Введите название произведения: ");
            string tittle = Console.ReadLine();

            Book book = _library.FindBookByTitle(tittle);

            if (book != null)
                Console.WriteLine($"Результат поиска: {book}");
            else
                Console.WriteLine("Книга не найдена");
        }

        public void FindBooksByAuthor()
        {
            Console.WriteLine("\n----- Поиск книг по автору -----\n");

            Console.Write("Введите автора произведения в формате \"И. О. Фамилия\": ");
            string author = Console.ReadLine();

            List<Book> booksByAuthor = _library.GetBooksByAuthor(author);

            if (booksByAuthor != null)
            {
                Console.WriteLine("Результат поиска:\n");

                foreach(Book book in booksByAuthor)
                    Console.WriteLine(book);
            }
            else
                Console.WriteLine("Книги не найдены");
        }

        public void FindBooksByYear()
        {
            Console.WriteLine("\n----- Поиск книг по году публикации -----\n");

            Console.Write("Введите год написания произведения: ");
            int year = Convert.ToInt32(Console.ReadLine());

            List<Book> booksByYear = _library.GetBooksByYear(year);

            if (booksByYear != null)
            {
                Console.WriteLine("Результат поиска:\n");

                foreach (Book book in booksByYear)
                    Console.WriteLine(book);
            }
            else
                Console.WriteLine("Книги не найдены");
        }

        public void FindBooksByGenre()
        {
            Console.WriteLine("\n----- Поиск книг по жанру -----\n");

            Console.Write("Введите жанр произведения: ");
            string genre = Console.ReadLine();

            List<Book> booksByGenre = _library.GetBooksByGenre(genre);

            if (booksByGenre != null)
            {
                Console.WriteLine("Результат поиска:\n");

                foreach (Book book in booksByGenre)
                    Console.WriteLine(book);
            }
            else
                Console.WriteLine("Книги не найдены");
        }

        public void PrintAllBooks()
        {
            Console.WriteLine("\n----- Список всех книг библиотеки -----\n");
            _library.PrintAllBooks();
        }

        public void DeleteBook()
        {
            Console.WriteLine("\n----- Удаление книги -----\n");

            Console.Write("Введите индекс книги для удаления: ");
            int index = Convert.ToInt32(Console.ReadLine());

            Book book = _library.GetBook(index - 1);
            _library.RemoveBook(book);

            PrintAllBooks();
        }

        public void AddBook()
        {
            Console.WriteLine("\n----- Добавление книги -----\n");

            Console.Write("Введите название: ");
            string tittle = Console.ReadLine();

            Console.Write("Введите автора: ");
            string author = Console.ReadLine();

            Console.Write("Введите жанр: ");
            string genre = Console.ReadLine();

            Console.Write("Введите год публикации: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Book book = new Book(tittle, author, year, genre);
            _library.AddBook(book);

            Console.WriteLine("\n----- Результат добавления -----\n");
            PrintAllBooks();
        }
    }
}