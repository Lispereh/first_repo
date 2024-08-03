using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{

    struct FoundationDate
    {
        private int year;
        private int month;
        private int day;

        public FoundationDate(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }

        public void setYear(int year) 
        { 
            this.year = year;
        }

        public int getYear() 
        { 
            return year; 
        }

        public void setMonth(int month)
        {
            this.month = month;
        }

        public int getMonth()
        {
            return month;
        }

        public void setDay(int day)
        {
            this.day = day;
        }

        public int getDay()
        {
            return day;
        }

        public void printFoundationDate()
        {
            Console.WriteLine($"Дата основания: {day:D2}.{month:D2}.{year}г.");
        }
    }

    internal class Journal
    {

        private string journalName;
        private FoundationDate foundationDate;
        private string journalDescription;
        private string phoneNumber;
        private string email;

        public Journal() : this("Имя", "Описание", "Номер телефона",
                                   "Email", 01, 01, 2000) { }

        public Journal(string journalName, string journalDescription, 
                       string phoneNumber, string email, int day, 
                       int month, int year)
        {
            this.journalName = journalName;
            this.foundationDate = new FoundationDate(year, month, day);
            this.journalDescription = journalDescription;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public void setJournalName(string journalName)
        {
            this.journalName = journalName;
        }

        public string getJournalName()
        {
            return journalName;
        }

        public void setFoundationDate(int day, int month, int year)
        {
            foundationDate.setDay(day);
            foundationDate.setMonth(month);
            foundationDate.setYear(year);
        }

        public int getFoundationDay()
        {
            return foundationDate.getDay();
        }

        public int getFoundationMonth()
        {
            return foundationDate.getMonth();
        }

        public int getFoundationYear()
        {
            return foundationDate.getYear();
        }

        public void setJournalDescription(string journalDescription)
        {
            this.journalDescription= journalDescription;
        }

        public string getJournalDescription()
        {
            return journalDescription;
        }

        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public string getPhoneNumber()
        {
            return phoneNumber;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getEmail()
        {
            return email;
        }

        public void printJournal()
        {
            Console.WriteLine($"Название журнала: \"{journalName}\"");
            foundationDate.printFoundationDate();
            Console.WriteLine($"Описание журнала: {journalDescription}");
            Console.WriteLine($"Номер телефона: {phoneNumber}");
            Console.WriteLine($"Email: {email}");
        }
    }
}