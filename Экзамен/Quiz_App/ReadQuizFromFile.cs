using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    // Чтение файла с викториной
    internal class ReadQuizFromFile
    {
        private string _path;

        public ReadQuizFromFile(string path)
        {
            _path = path;
        }

        // Чтение данных из файла
        public QuizManager Reading()
        {
            try
            {
                // Название викторины - название файла без расширения
                string quizName = Path.GetFileNameWithoutExtension(_path);
                Dictionary<string, List<string>> questionsAnswers = new Dictionary<string, List<string>>();

                using (StreamReader reader = new StreamReader(_path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] arrayLine = line.Split('|');
                        string key = arrayLine[0].Trim();

                        string[] values = arrayLine[1].Split(new char[] { ';' },
                                          StringSplitOptions.RemoveEmptyEntries);
                        List<string> listValues = new List<string>();

                        for(int i = 0; i < values.Length; i++)
                            listValues.Add(values[i].Trim());

                        questionsAnswers.Add(key, listValues);
                    }
                }

                return new QuizManager(quizName, questionsAnswers);
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка: " + e.Message);
            }

            return null;
        }
    }
}