using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name1 = inputName();
            string description1 = inputDescription();

            int day1 = inputDay();
            int month1 = inputMonth();
            int year1 = inputYear();

            string phoneNumber1 = inputPhoneNumber();
            string email1 = inputEmail();

            Journal journal1 = new Journal(name1, description1, phoneNumber1, 
                                           email1, day1, month1, year1);

            Console.WriteLine();
            journal1.printJournal();
            Console.WriteLine();

            Journal journal2 = new Journal();

            string name2 = inputName();
            string description2 = inputDescription();

            int day2 = inputDay();
            int month2 = inputMonth();
            int year2 = inputYear();

            string phoneNumber2 = inputPhoneNumber();
            string email2 = inputEmail();

            setParameters(ref journal2, name2, description2, phoneNumber2, 
                          email2, day2, month2, year2);

            Console.WriteLine();
            print(ref journal2);

            Console.ReadKey();
        }

        static string inputName()
        {
            Console.Write("Введите название журнала: ");
            string name = Console.ReadLine();

            return name;
        }

        static string inputDescription()
        {
            Console.Write("Введите описание журнала: ");
            string description = Console.ReadLine();

            return description;
        }

        static int inputDay()
        {
            Console.Write("Введите день основания журнала: ");
            int day = Convert.ToInt32(Console.ReadLine());

            return day;
        }

        static int inputMonth()
        {
            Console.Write("Введите месяц основания журнала: ");
            int month = Convert.ToInt32(Console.ReadLine());

            return month;
        }

        static int inputYear()
        {
            Console.Write("Введите год основания журнала: ");
            int year = Convert.ToInt32(Console.ReadLine());

            return year;
        }

        static string inputPhoneNumber()
        {
            Console.Write("Укажите телефон журнала: ");
            string phoneNumber = Console.ReadLine();

            return phoneNumber;
        }

        static string inputEmail()
        {
            Console.Write("Укажите email журнала: ");
            string email = Console.ReadLine();

            return email;
        }

        static void setParameters(ref Journal journal, string name, string description,
                                  string phoneNumber, string email, int day, int month, int year)
        {
            journal.setJournalName(name);
            journal.setJournalDescription(description);
            journal.setPhoneNumber(phoneNumber);
            journal.setEmail(email);
            journal.setFoundationDate(day, month, year);
        }

        static void print(ref Journal journal)
        {
            Console.WriteLine($"Название журнала: \"{journal.getJournalName()}\"");
            Console.WriteLine($"Дата основания: {journal.getFoundationDay():D2}." +
                              $"{journal.getFoundationMonth():D2}." +
                              $"{journal.getFoundationYear()}г.");

            Console.WriteLine($"Описание журнала: {journal.getJournalDescription()}");
            Console.WriteLine($"Номер телефона: {journal.getPhoneNumber()}");
            Console.WriteLine($"Email: {journal.getEmail()}");
        }
    }
}