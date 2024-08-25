using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    // Управление возможностями викторины
    internal class QuizManager
    {
        public Quiz _quiz;

        public QuizManager(string quizName,
                           Dictionary<string, List<string>> questionsAnswers)
        {
            _quiz = new Quiz(quizName, questionsAnswers);
        }

        public void PassQuiz(User user, List<User> users)
        {
            int questionIndex = 1;
            int score = 0;

            Console.WriteLine($"----- Викторина \"{_quiz.GetQuizName()}\" -----\n");

            foreach (var question in _quiz.GetQuestionsAnswers())
            {
                Console.WriteLine($"{question.Key}");
                questionIndex++;

                int correctAnswer1 = -1;
                int correctAnswer2 = -1;
                int anserIndex = 0;

                foreach (var answer in question.Value)
                {
                    if (answer.StartsWith("*") && correctAnswer1 == -1)
                        correctAnswer1 = anserIndex;
                    else if(answer.StartsWith("*") && correctAnswer1 != -1)
                        correctAnswer2 = anserIndex;

                    Console.WriteLine($"{anserIndex + 1}. {answer.Replace("*", "")}");
                    anserIndex++;
                }

                Console.Write("\nОтвет: ");
                string userAnswer = Console.ReadLine();

                score = CheckAnswer(correctAnswer1, correctAnswer2,
                                    score, userAnswer);
            }

            Console.WriteLine($"Викторина окончена! " +
                              $"Ваш результат: {score}");

            user.AddResults(_quiz.GetQuizName(), score);

            ShowTopTwenty showTopTwenty = new ShowTopTwenty();
            int place = showTopTwenty.UserPlaceInTop(users, _quiz.GetQuizName(), user);

            if (place > 0)
                Console.WriteLine($"Ваше место в ТОП-20: {place}\n");
            else
                Console.WriteLine("Вы не попали в ТОП-20\n");
        }

        // Проверка корректности ответа пользователя
        public int CheckAnswer(int correctAnswer1, int correctAnswer2,
                               int score, string userAnswer)
        {

            
            string[] userAnswers = userAnswer.Split(',');

            if(userAnswers.Length == 1)
            {
                if(correctAnswer1 == (Convert.ToInt32(userAnswers[0].Trim()) - 1)
                   && correctAnswer2 == -1)
                {
                    Console.WriteLine("Ответ верный!\n");
                    score++;
                }
                else
                    Console.WriteLine("Ответ неверный!\n");
            }
            else if(userAnswers.Length == 2)
            {
                if (correctAnswer1 == (Convert.ToInt32(userAnswers[0].Trim()) - 1)
                    && correctAnswer2 == (Convert.ToInt32(userAnswers[1].Trim()) - 1))
                {
                    Console.WriteLine("Ответ верный!\n");
                    score++;
                }
                else
                    Console.WriteLine("Ответ неверный!\n");
            }
            else
                Console.WriteLine("Ответ неверный!\n");

            return score;
        }
    }
}