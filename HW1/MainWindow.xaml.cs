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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            buttonGuese.Click += GueseNumber;
        }

        private void GueseNumber(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int number = 0;
            List<int> list = new List<int>();
            MessageBoxResult messageBoxResult;

            do
            {
                if (list == null)
                    number = random.Next(1, 11);
                else
                {
                    bool repeat = false;
                    do
                    {
                        number = random.Next(1, 11);

                        if (list.Contains(number))
                            number = random.Next(1, 11);
                        else
                            repeat = true;
                    } while (repeat == false);
                }

                messageBoxResult = MessageBox.Show($"Я думаю, вы задумали {number}", "Угадываем число",
                                                   MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    textBlock1.Text = "Я угадал ваше число";
                    break;
                }
                else
                {
                    textBlock1.Text = "Позвольте мне попробовать еще раз";
                    list.Add(number);
                }

            } while (messageBoxResult == MessageBoxResult.No);
        }
    }
}