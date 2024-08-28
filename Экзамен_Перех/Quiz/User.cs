using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    // Данные пользователя
    internal class User
    {
        private string _login;
        private string _password;
        private DateTime _birthDate;

        private Dictionary<string, int> _lastResults;

        public User(string login, string password,
                    DateTime birthDate,
                    Dictionary<string, int> lastResults)
        {
            _login = login;
            _password = password;
            _birthDate = birthDate;
            _lastResults = lastResults;
        }

        public string GetLogin() => _login;
        public string GetPassword() => _password;
        public DateTime GetBirthDate() => _birthDate;
        public Dictionary<string, int> GetLastResults() => _lastResults;

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
            if (_lastResults.ContainsKey(quizName))
                _lastResults.Remove(quizName);

            _lastResults.Add(quizName, score);
        }

        public void ShowLastResults()
        {
            if (_lastResults.Count != 0)
            {
                Console.WriteLine("----- Результаты прошлых викторин -----");

                foreach (var item in _lastResults)
                    Console.WriteLine($"{item.Key} - {item.Value}");

                Console.WriteLine();
            }
            else
                Console.WriteLine("Нет результатов прошлых викторин\n");
        }
    }
}