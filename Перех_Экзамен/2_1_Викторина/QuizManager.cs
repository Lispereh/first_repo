using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_2_Quiz_App
{
    /// <summary>
    /// Управление возможностями викторины
    /// </summary>
    internal class QuizManager
    {
        /// <summary>
        /// Викторина по одной теме
        /// </summary>
        public void PassQuiz(Quiz quiz, User user)
        {
            List<string> questions = quiz.GetQuestions();
            List<string> answers = quiz.GetAnswers();

            int questionIndex = 0;
            int answerIndex = 0;
            int score = 0;

            Console.WriteLine($"----- Викторина \"{quiz.GetQuizName()}\" -----\n");

            while (questionIndex < questions.Count)
            {
                // Отображение вопроса на экран
                Console.WriteLine(questions[questionIndex]);
                questionIndex++;

                int correctAnswer = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (answers[answerIndex].StartsWith("*"))
                        correctAnswer = i + 1;

                    Console.WriteLine($"{i + 1}. {answers[answerIndex].Replace("*", "")}");
                    answerIndex++;
                }

                Console.Write("\nОтвет: ");
                int answer = Convert.ToInt32(Console.ReadLine());

                score = CheckAnswer(answer, correctAnswer, score);
            }

            Console.WriteLine($"Викторина окончена! " +
                              $"Ваш результат: {score}\n");

            user.AddResults(quiz.GetQuizName(), score);
        }

        /// <summary>
        /// Проверка корректности ответа пользователя
        /// </summary>
        public int CheckAnswer(int answer, int correctAnswer, int score)
        {
            if (answer == correctAnswer)
            {
                Console.WriteLine("Ответ верный!\n");
                score++;
            }
            else
                Console.WriteLine("Ответ неверный!\n");

            return score;
        }
    }
}