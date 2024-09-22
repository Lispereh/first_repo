using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfApp3
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public int CorrectAnswer { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Question> questions = new ObservableCollection<Question>();
        const string FILE_NAME = "questions.xml";

        public MainWindow()
        {
            InitializeComponent();
            LoadFromFile();

            listViewQuestions.ItemsSource = questions;
            sendQuestion.Click += SendQuestion_Click;
        }

        private void SendQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string questionText = txtBoxQuestion.Text;
                if (questionText == string.Empty)
                    throw new Exception("Поле вопроса пусто!");

                string answer1 = txtBoxAnswer1.Text;
                if (answer1 == string.Empty)
                    throw new Exception("Поле ответа №1 пусто!");

                string answer2 = txtBoxAnswer2.Text;
                if (answer2 == string.Empty)
                    throw new Exception("Поле ответа №2 пусто!");

                string answer3 = txtBoxAnswer3.Text;
                if (answer3 == string.Empty)
                    throw new Exception("Поле ответа №3 пусто!");

                if(comboBox.SelectedItem == null)
                    throw new Exception("Корректный ответ не выбран!");
                int correctAnswer = Convert.ToInt32(((ComboBoxItem)comboBox.SelectedItem).Content);

                questions.Add(new Question()
                {
                    QuestionText = questionText,
                    Answer1 = answer1,
                    Answer2 = answer2,
                    Answer3 = answer3,
                    CorrectAnswer = Convert.ToInt32(((ComboBoxItem)comboBox.SelectedItem).Content)
                });

                SaveToFile();

                // Очистка текстовых полей после добавления
                txtBoxQuestion.Clear();
                txtBoxAnswer1.Clear();
                txtBoxAnswer2.Clear();
                txtBoxAnswer3.Clear();
                comboBox.SelectedIndex = -1; // Сброс выбора в ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveToFile()
        {
            try
            {
                using (FileStream fs = new FileStream(FILE_NAME, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Question>));

                    serializer.Serialize(fs, questions);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void LoadFromFile()
        {
            if (!File.Exists(FILE_NAME)) return;
            try
            {
                using (FileStream fs = new FileStream(FILE_NAME, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Question>));

                    questions = (ObservableCollection<Question>)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}