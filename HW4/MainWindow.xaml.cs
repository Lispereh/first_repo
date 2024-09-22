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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnChangeBC.Click += BtnChangeBC_Click;
        }

        private void BtnChangeBC_Click(object sender, RoutedEventArgs e)
        {
            Random randomColor = new Random();
            window1.Background = new SolidColorBrush(Color.FromRgb((byte)randomColor.Next(0, 256),
                                                     (byte)randomColor.Next(0, 256),
                                                     (byte)randomColor.Next(0, 256))); // 256, т.к. maxValue не включается
        }
    }
}