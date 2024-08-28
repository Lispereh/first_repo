using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editing_Utility
{
    internal class WorkOfProgram
    {
        private Menu _menu;
        private Quiz _quiz;
        private QuizManager _quizManager;

        public WorkOfProgram()
        {
            _menu = new Menu();
            _quizManager = new QuizManager();
        }

        public void ProgramWorks()
        {
            UserSignIn(); // Вход пользователя
            EditorWorks(); // Редактирование
        }

        public void EditorWorks()
        {
            int choice = 1;

            do
            {
                Editing();

                Console.WriteLine("\nПродолжить? 1 - Да, Любая клавиша - Нет.");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice != 1)
                    return;

                Console.Clear();

            } while (choice == 1);
        }

        public void Editing()
        {
            int codeMenuWhatEdit = ChoiceWhatEdit();
            Console.Clear();

            if(codeMenuWhatEdit == 1)
                EditQuestions();
            else if(codeMenuWhatEdit == 2)
                EditAnswers();

            WriteChangesToFile();
        }

        public void WriteChangesToFile()
        {
            WriteQuizToFile writeQuizToFile = new WriteQuizToFile($"{_quiz.GetQuizName()}.txt");
            writeQuizToFile.Writing(_quiz);
        }

        public void EditAnswers()
        {
            Console.WriteLine("----- Редактирование ответов -----\n");

            int choice = ChoiceQuiz();
            ReadingFiles(choice);

            EditingAnswers();
        }

        public void EditingAnswers()
        {
            Console.WriteLine($"\n----- Список вопросов викторины: " +
                              $"\"{_quiz.GetQuizName()}\" -----\n");

            _quizManager.ShowQuestionsBeforEdit(_quiz);

            Console.Write("\nВведите номер вопроса для редактирования ответов к нему: ");
            int questionIndex = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            _quizManager.ShowAnswersBeforEdit(_quiz, questionIndex - 1);

            Console.Write("\nВведите номер ответа для редактирования: ");
            int answerIndex = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nВведите новый ответ: ");
            string newAnswer = Console.ReadLine();

            bool CheckEditing = _quizManager.EditAnswers(_quiz, questionIndex - 1, answerIndex - 1, newAnswer);

            if (CheckEditing)
            {
                Console.WriteLine("Ответ успешно отредактирован!\n");
                Console.WriteLine("----- Обновлённый вариант ответов -----\n");

                _quizManager.ShowAnswersBeforEdit(_quiz, questionIndex - 1);
            }
            else
                Console.WriteLine("Не удалось отредактировать ответ. Повторите попытку\n");
        }

        public void EditQuestions()
        {
            Console.WriteLine("----- Редактирование вопросов -----\n");

            int choice = ChoiceQuiz();
            ReadingFiles(choice);

            EditingQuestion();
        }

        public void EditingQuestion()
        {
            Console.WriteLine($"\n----- Список вопросов викторины " +
                              $"\"{_quiz.GetQuizName()}\" -----\n");

            _quizManager.ShowQuestionsBeforEdit(_quiz);

            Console.Write("\nВведите номер вопроса для редактирования: ");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nВведите новый вопрос: ");
            string newQuestion = Console.ReadLine();

            bool CheckEditing = _quizManager.EditQuestions(_quiz, index - 1, newQuestion);

            if (CheckEditing)
            {
                Console.WriteLine("Вопрос успешно отредактирован!\n");
                Console.WriteLine($"----- Обновлённый список вопросов викторины " +
                                  $"{_quiz.GetQuizName()} -----\n");

                _quizManager.ShowQuestionsBeforEdit(_quiz);
            }
            else
                Console.WriteLine("Не удалось отредактировать вопрос. Повторите попытку\n");
        }

        public void ReadingFiles(int choice)
        {
            if (choice == 0)
                StartQuiz("Основные понятия ООП.txt");
            else if (choice == 1)
                StartQuiz("Классы, структуры.txt");
            else if (choice == 2)
                StartQuiz("Коллекции.txt");
        }

        public int ChoiceQuiz()
        {
            int choice = 0;

            do
            {
                _menu.ShowQuizesList();
                choice = _menu.ChoiceCodeMenu();

                if (choice < 1 || choice > 4)
                {
                    Console.Clear();
                    Console.WriteLine("Указан неверный код меню. Повторите попытку.\n");
                }
                if (choice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Выход выполнен успешно.");
                    break;
                }

            } while (choice < 1 || choice > 4);

            return choice - 1;
        }

        public void StartQuiz(string path)
        {
            ReadQuizFromFile readQuizFromFile = new ReadQuizFromFile(path);
            _quiz = readQuizFromFile.Reading();
        }

        public int ChoiceWhatEdit()
        {
            int choice = 0;

            do
            {
                _menu.MainEditingMenu();
                choice = _menu.ChoiceCodeMenu();

                if (choice < 1 || choice > 3)
                {
                    Console.Clear();
                    Console.WriteLine("Указан неверный код меню. Повторите попытку.\n");
                }
                if(choice == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Выход выполнен успешно.");
                    return 0;
                }
            } while (choice < 1 || choice > 3);

            return choice;
        }

        public void UserSignIn()
        {
            User user = null;

            do
            {
                Console.WriteLine("----- Вход в утилиту -----\n");
                user = DataEntry();

                if (user == null)
                {
                    Console.WriteLine("Повторить попытку? 1 - Да, Любая клавиша - Нет.");
                    Console.Write("Введите код меню: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice != 1)
                        return;

                    Console.Clear();
                }
            } while (user == null);
        }

        public User DataEntry()
        {
            Console.Write("Логин: ");
            string login = Console.ReadLine();

            Console.Write("Пароль: ");
            string password = Console.ReadLine();

            return CheckDataEntry(login, password);
        }

        public List<User> CreateUsersList()
        {
            ReadUserDataFromFile readUserDataFromFile = new ReadUserDataFromFile();
            return readUserDataFromFile.Reading();
        }

        public User CheckDataEntry(string login, string password)
        {
            SignIn signIn = new SignIn(CreateUsersList());
            return signIn.UserSignIn(login, password);
        }
    }
}