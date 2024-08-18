using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Editing_Utility
{
    internal class QuizManager
    {
        public bool EditQuestions(Quiz quiz,
                                  int questionIndex,
                                  string newQuestion)
        {
            if (quiz.GetQuestions()[questionIndex] != null)
            {
                quiz.GetQuestions()[questionIndex] = newQuestion;
                return true;
            }

            return false;
        }

        public bool EditAnswers(Quiz quiz, int questionIndex, 
                                int answerIndex, string newAnswer)
        {
            if(quiz.GetAnswers()[answerIndex] != null)
            {
                int startIndex = questionIndex * 4;
                quiz.GetAnswers()[startIndex + answerIndex] = newAnswer;

                return true;
            }

            return false;
        }

        public void ShowAnswersBeforEdit(Quiz quiz,
                                         int questionIndex)
        {
            if (quiz.GetQuestions()[questionIndex] != null)
            {
                Console.WriteLine(quiz.GetQuestions()[questionIndex]);

                int startIndex = questionIndex * 4;

                for (int i = 0; i < 4; i++)
                {
                    // Предварительная проверка границ списка ответов
                    if (startIndex + i < quiz.GetAnswers().Count)
                    {
                        Console.WriteLine($"{i + 1}. {quiz.GetAnswers()[startIndex + i]}");
                    }
                }
            }
        }

        public void ShowQuestionsBeforEdit(Quiz quiz)
        {
            int i = 0;
            foreach(string question in quiz.GetQuestions())
            {
                Console.WriteLine($"{i + 1}. {question}");
                i++;
            }
        }
    }
}