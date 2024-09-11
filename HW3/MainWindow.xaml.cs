using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Expression expression;

        public MainWindow()
        {
            InitializeComponent();
            expression = new Expression();
            ClickButtons();
            buttonEqually.Click += ButtonEqually_Click;
            buttonCE.Click += buttonCE_Click;
            buttonDeleteLastChar.Click += buttonDeleteLastChar_Click;
            buttonC.Click += buttonC_Click;
        }

        private void buttonC_Click(object sender, RoutedEventArgs e)
        {
            textBlockBottom.Text = string.Empty;
            textBlockTop.Text = string.Empty;
        }

        private void buttonDeleteLastChar_Click(object sender, RoutedEventArgs e)
        {
            textBlockBottom.Text = textBlockBottom.Text.Remove(textBlockBottom.Text.Length - 1);
        }

        private void buttonCE_Click(object sender, RoutedEventArgs e)
        {
            textBlockBottom.Text = string.Empty;
        }

        private void ButtonEqually_Click(object sender, RoutedEventArgs e)
        {
            textBlockTop.Text += textBlockBottom.Text;
            expression.ExpressionString = textBlockTop.Text;

            ShowResult();
        }

        private void ShowResult()
        {
            expression.CountResult();
            textBlockBottom.Text = Convert.ToString(expression.Result);
        }

        private void AddToOperationsHistory(object sender, RoutedEventArgs e, string symbol)
        {
            // Проверка на ввод чисел, начинающихся с нуля
            if (textBlockBottom.Text == "0" && symbol != ",")
            {
                // Если уже есть 0 и вводится другая цифра
                MessageBox.Show("Число не может начинаться с '0'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                textBlockBottom.Text = string.Empty;
            }

            if (expression.Result != 0
                && textBlockBottom.Text != string.Empty
                && Convert.ToDecimal(textBlockBottom.Text) == expression.Result)
                textBlockBottom.Text = string.Empty;

            if (symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/")
            {
                textBlockTop.Text += textBlockBottom.Text;
                textBlockTop.Text += symbol;
                textBlockBottom.Text = string.Empty;
            }
            else
                textBlockBottom.Text += symbol;
        }

        private void ClickButtons()
        {
            buttonZero.Click += (sender, e) => AddToOperationsHistory(sender, e, "0");
            buttonOne.Click += (sender, e) => AddToOperationsHistory(sender, e, "1");
            buttonTwo.Click += (sender, e) => AddToOperationsHistory(sender, e, "2");
            buttonThree.Click += (sender, e) => AddToOperationsHistory(sender, e, "3");
            buttonFour.Click += (sender, e) => AddToOperationsHistory(sender, e, "4");
            buttonFive.Click += (sender, e) => AddToOperationsHistory(sender, e, "5");
            buttonSix.Click += (sender, e) => AddToOperationsHistory(sender, e, "6");
            buttonSeven.Click += (sender, e) => AddToOperationsHistory(sender, e, "7");
            buttonEight.Click += (sender, e) => AddToOperationsHistory(sender, e, "8");
            buttonNine.Click += (sender, e) => AddToOperationsHistory(sender, e, "9");

            buttonDivision.Click += (sender, e) => AddToOperationsHistory(sender, e, "/");
            buttonMultiplication.Click += (sender, e) => AddToOperationsHistory(sender, e, "*");
            buttonMinus.Click += (sender, e) => AddToOperationsHistory(sender, e, "-");
            buttonPlus.Click += (sender, e) => AddToOperationsHistory(sender, e, "+");
            buttonPoint.Click += (sender, e) => AddToOperationsHistory(sender, e, ",");
        }
    }
}