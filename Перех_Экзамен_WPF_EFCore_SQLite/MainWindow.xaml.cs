using Expenes_Exam_Beth_Perekh.Contexts;
using Expenes_Exam_Beth_Perekh.Models;
using Expenes_Exam_Beth_Perekh.Repositories;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Expenes_Exam_Beth_Perekh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExpensesTrackerContext _context;
        private ExpenseRepository _repository;

        public MainWindow()
        {
            InitializeComponent();

            _context = new ExpensesTrackerContext();
            _repository = new ExpenseRepository(_context);

            dataGridCategories.ItemsSource = _repository.GetAllCategoriesObservable();
            buttonAddCAtegory.Click += ButtonAddCAtegory_Click;
            buttonDeleteCategories.Click += ButtonDeleteCategories_Click;

            comboBoxCategory.ItemsSource = _repository.GetAllCategoriesObservable();

            dataGridExpensesTable.ItemsSource = _repository.GetAllExpensesObservable();

            buttonAddExpense.Click += ButtonAddExpense_Click;
            buttonDeleteExpense.Click += ButtonDeleteExpense_Click;

            dataGridDayOfWeek.ItemsSource = _repository.GetAVGExpensesByDayOfWeek();
            buttonUpdateDayOfWeek.Click += ButtonUpdateDayOfWeek_Click;

            dataGridSumExpensesPeriod.ItemsSource = _repository.GetExpensesPeriods();
            buttonUpdateExpensesPeriod.Click += ButtonUpdateExpensesPeriod_Click;

            buttonFilter.Click += ButtonFilter_Click;
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            DateTime? startDate = datePickerStart.SelectedDate;
            DateTime? endDate = datePickerEnd.SelectedDate;
            string categoryName = textBoxCategoryFilter.Text.Trim();
            string keyword = textBoxKeyword.Text.Trim();

            var filteredExpenses = _repository.GetFilteredExpenses(startDate, endDate, categoryName, keyword);
            dataGridFilteredExpenses.ItemsSource = filteredExpenses;
        }

        private void ButtonUpdateExpensesPeriod_Click(object sender, RoutedEventArgs e)
        {
            var expensesPeriods = _repository.GetExpensesPeriods();
            dataGridSumExpensesPeriod.ItemsSource = expensesPeriods;
        }

        private void ButtonUpdateDayOfWeek_Click(object sender, RoutedEventArgs e)
        {
            var AVGExpensesByDayOfWeek = _repository.GetAVGExpensesByDayOfWeek();
            dataGridDayOfWeek.ItemsSource = AVGExpensesByDayOfWeek;
        }

        private void ButtonDeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridExpensesTable.SelectedItems != null)
            {
                List<Expense> expensesToDelete = new List<Expense>();
                foreach (var expense in dataGridExpensesTable.SelectedItems)
                    expensesToDelete.Add(expense as Expense);

                _repository.DeleteExpenses(expensesToDelete);
            }
            else
                ShowError("Select categories!");
        }

        private void ButtonAddExpense_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dateTime = (DateTime)datePickerExpenseDate.SelectedDate;
                Category category = comboBoxCategory.SelectedItem as Category;
                decimal amount = Convert.ToDecimal(textBoxExpenseAmount.Text);
                string description = textBoxExpenseDescription.Text;

                _repository.AddExpense(new Expense()
                {
                    Date = dateTime != null ? (DateTime)dateTime : DateTime.Now,
                    Category = category,
                    Amount = amount,
                    Description = description
                });

                textBoxExpenseAmount.Text = string.Empty;
                textBoxExpenseDescription.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ButtonDeleteCategories_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridCategories.SelectedItems != null)
            {
                List<Category> categoriesToDelete = new List<Category>();
                foreach (var item in dataGridCategories.SelectedItems)
                    categoriesToDelete.Add(item as Category);

                _repository.DeleteCategories(categoriesToDelete);
            }
            else
                ShowError("Select categories!");
        }

        private void ButtonAddCAtegory_Click(object sender, RoutedEventArgs e)
        {
            var categoryName = textBoxCategoryName.Text.Trim();

            if (categoryName != string.Empty)
            {
                _repository.AddCategory(new Models.Category()
                {
                    Name = categoryName
                });
                textBoxCategoryName.Text = string.Empty;
            }
            else
                ShowError("Category's name can't be empty!");
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}