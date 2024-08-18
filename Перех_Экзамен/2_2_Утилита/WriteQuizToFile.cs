using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editing_Utility
{
    internal class WriteQuizToFile
    {
        private string _path;

        public WriteQuizToFile() : this("questions.txt") { }

        public WriteQuizToFile(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Запись данных викторины в файл
        /// </summary>
        public void Writing(Quiz quiz)
        {
            try
            {
                List<string> lines = new List<string>();

                // Добавляем вопросы и ответы в список строк
                for (int i = 0; i < quiz.GetQuestions().Count; i++)
                {
                    lines.Add(quiz.GetQuestions()[i]);
                    if (i < quiz.GetAnswers().Count)
                        lines.Add(quiz.GetAnswers()[i]);
                }

                // Записываем данные в файл
                File.WriteAllLines(_path, lines);
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка: " + e.Message);
            }
        }
    }
}