using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_2_Quiz_App
{
    /// <summary>
    /// Хранение данных викторины
    /// </summary>
    internal class Quiz
    {
        private string _quizName;
        private List<string> _questions;
        private List<string> _answers;

        public Quiz() : this(null, null, null) { }

        public Quiz(List<string> questions,
                    List<string> answers,
                    string quizName)
        {
            _questions = questions;
            _answers = answers;
            _quizName = quizName;
        }

        /// <summary>
        /// Получение названия викторины
        /// </summary>
        public string GetQuizName()
        {
            return _quizName;
        }

        /// <summary>
        /// Получение списка вопросов
        /// </summary>
        public List<string> GetQuestions()
        {
            return _questions;
        }

        /// <summary>
        /// Получение списка ответов
        /// </summary>
        public List<string> GetAnswers()
        {
            return _answers;
        }
    }
}