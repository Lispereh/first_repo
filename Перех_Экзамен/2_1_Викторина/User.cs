using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_2_Quiz_App
{
    /// <summary>
    /// Данные пользователя
    /// </summary>
    internal class User
    {
        private string _login;
        private string _password;
        private DateTime _birthDate;

        private Dictionary<string, int> _lastResults;

        public User() : this(null, null,
                             new DateTime(),
                             new Dictionary<string, int>()) { }

        public User(string login, string password,
                    DateTime birthDate, 
                    Dictionary<string, int> lastResults)
        {
            _login = login;
            _password = password;
            _birthDate = birthDate;
            _lastResults = lastResults;
        }

        public string GetLogin()
        {
            return _login;
        }

        public string GetPassword()
        {
            return _password;
        }

        public DateTime GetBirthDate()
        {
            return _birthDate;
        }

        public Dictionary<string, int> GetLastResults()
        {
            return _lastResults;
        }

        public void ChangePassword(string password)
        {
            _password = password;
        }

        public void ChangeBirthDate(DateTime birthDate)
        {
            _birthDate = birthDate;
        }

        public void AddResults(string quizName, int score)
        {
            // Храним только последний результат викторины
            if(_lastResults.ContainsKey(quizName))
                _lastResults.Remove(quizName);

            _lastResults.Add(quizName, score);
        }

        public void ShowLastResults()
        {
            if(_lastResults.Count != 0)
            {
                Console.WriteLine("----- Результаты прошлых викторин -----");
                foreach(var item in _lastResults)
                    Console.WriteLine($"{item.Key} - {item.Value}");
                Console.WriteLine();
            }
            else
                Console.WriteLine("Нет результатов прошлых викторин\n");
        }
    }
}