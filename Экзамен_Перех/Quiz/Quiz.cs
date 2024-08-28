using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    // Хранение данных викторины
    internal class Quiz
    {
        private string _quizName;
        private Dictionary<string, List<string>> _questionsAnswers;

        public Quiz(string quizName,
                    Dictionary<string, List<string>> questionsAnswers)
        {
            _quizName = quizName;
            _questionsAnswers = questionsAnswers;
        }

        // Получение названия викторины
        public string GetQuizName() => _quizName;

        // Получение вопросов и ответов
        public Dictionary<string, List<string>> GetQuestionsAnswers() => _questionsAnswers;

    }
}