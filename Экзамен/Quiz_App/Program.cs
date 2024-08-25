using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ReadQuizFromFile readQuizFromFile = new ReadQuizFromFile("Основные понятия ООП.txt");
            //QuizManager quizManager = readQuizFromFile.Reading();
            ////quizManager.PassQuiz();

            //Console.Write("Логин: ");
            //string login = Console.ReadLine();

            //Console.Write("Пароль: ");
            //string password = Console.ReadLine();

            //ReadUserDataFromFile readUserDataFromFile = new ReadUserDataFromFile();

            //List<User> users = readUserDataFromFile.Reading();

            //SignInOrSignUp signInOrSignUp = new SignInOrSignUp(users);

            //signInOrSignUp.SignIn(login, password);

            //ShowTopTwenty showTopTwenty = new ShowTopTwenty();
            //showTopTwenty.TopTwenty(users, quizManager._quiz.GetQuizName());

            PerformMenuActions performMenuActions = new PerformMenuActions();
            performMenuActions.WorkOfProgram();

            Console.ReadKey();
        }
    }
}