using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task_2_Quiz_App
{
    /// <summary>
    /// Чтение файла с викториной
    /// </summary>
    internal class ReadQuizFromFile
    {
        private string _path;

        public ReadQuizFromFile() : this("questions.txt") { }

        public ReadQuizFromFile(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Чтение данных из файла
        /// </summary>
        public Quiz Reading()
        {
            try
            {
                string[] text = File.ReadAllLines(_path);

                // Название викторины - название файла без расширения
                string quizName = Path.GetFileNameWithoutExtension(_path);

                List<string> questions = new List<string>();
                List<string> answers = new List<string>();

                for (int i = 0; i < text.Length; i++)
                {
                    if (i % 5 == 0)
                        questions.Add(text[i]);
                    else
                        answers.Add(text[i]);
                }

                return new Quiz(questions, answers, quizName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка: " + e.Message);
            }

            return null;
        }
    }
}