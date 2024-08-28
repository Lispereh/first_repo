using System;
using System.IO;
using System.Collections.Generic;

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

                // Получаем количество вопросов и ответов
                List<string> questions = quiz.GetQuestions();
                List<string> answers1 = quiz.GetAnswers();
                List<List<string>> answers = new List<List<string>>();

                int counter = 0;

                // Создаем список ответов
                for (int i = 0; i < questions.Count; i++)
                {
                    List<string> list = new List<string>();

                    // Добавляем до 4 ответов для каждого вопроса
                    for (int j = 0; j < 4; j++)
                    {
                        if (counter < answers1.Count) // Проверяем, что индекс не выходит за пределы
                        {
                            list.Add(answers1[counter]);
                            counter++;
                        }
                        else
                        {
                            break; // Если нет больше ответов, выходим из цикла
                        }
                    }

                    answers.Add(list);
                }

                // Добавляем вопросы и ответы в список строк
                for (int i = 0; i < questions.Count; i++)
                {
                    lines.Add(questions[i]); // Добавляем вопрос

                    // Добавляем варианты ответов
                    if (i < answers.Count && answers[i].Count > 0) // Проверяем, что есть ответы для вопроса
                    {
                        for (int j = 0; j < Math.Min(4, answers[i].Count); j++) // Добавляем до 4 ответов
                        {
                            lines.Add(answers[i][j]); // Добавляем каждый ответ
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: недостаточно вариантов ответов для вопроса {i + 1}");
                    }
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