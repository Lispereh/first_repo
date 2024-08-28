using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal class ShowTopTwenty
    {
        private Dictionary<string, int> _sortedResults;

        public void TopTwenty(List<User> users, string quizName)
        {
            SortList(users, quizName);
            TopTwentyShow(quizName);
        }

        public void SortList(List<User> users, string quizName)
        {
            Dictionary<string, int> usersResults = new Dictionary<string, int>();

            foreach (var user in users)
                if (user.GetLastResults().ContainsKey(quizName))
                    usersResults.Add(user.GetLogin(), user.GetLastResults()[quizName]);

            // Сортировка и создание нового словаря
            _sortedResults = usersResults.OrderByDescending(x => x.Value).Take(20).ToDictionary(x => x.Key, x => x.Value);
        }

        public int UserPlaceInTop(List<User> users, string quizName, User user)
        {
            SortList(users, quizName);
            int counter = 0;
            foreach (var result in _sortedResults)
            {
                if (result.Key == user.GetLogin() && counter < 20)
                    return counter + 1;
                counter++;
            }

            return -1;
        }

        public void TopTwentyShow(string quizName)
        {
            if (_sortedResults.Count == 0)
            {
                Console.WriteLine("Нет результатов для отображения.");
                return;
            }

            int counter = 1;

            Console.WriteLine($"\nТОП-20 пользователей в викторине \"{quizName}\"\n");

            foreach (var user in _sortedResults)
            {
                Console.WriteLine($"{counter}. {user.Key}: {user.Value} очков");
                counter++;
            }

            Console.WriteLine("\n");
        }
    }
}