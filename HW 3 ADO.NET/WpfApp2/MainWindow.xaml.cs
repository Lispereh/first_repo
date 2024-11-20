using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
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
using WpfApp2.Models;
using WpfApp2.Repositories;
using System.Configuration;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SqlConnection connection;
        private EmployeesRepository empRepo;
        private ProductsRepository prodRepo;
        private SalesRepository salesRepo;

        public DataSet dataSet {  get; set; }
        public SqlDataAdapter DataAdapterEmployees { get; set; }
        public SqlDataAdapter DataAdapterProducts { get; set; }
        public SqlDataAdapter DataAdapterSales { get; set; }



        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Sale> Sales { get; set; }
        public List<TextBox> ProductInputs { get; set; }

        TextBox textBoxCustomerInput;
        TextBox textBoxQuantity;
        ComboBox comboBoxProducts;
        ComboBox comboBoxEmployees;


        public MainWindow()
        {
            InitializeComponent();
            dataSet = new DataSet();

            try
            {
                string connectionString = ConfigurationManager
                                          .ConnectionStrings["MyConnString"]
                                          .ConnectionString;

                connection = new SqlConnection(connectionString);
                connection.Open();

                DataAdapterEmployees = GetEmployeesAdapter(connection);
                DataAdapterProducts = GetProductsAdapter(connection);
                DataAdapterSales = GetSalesAdapter(connection);

                empRepo = new EmployeesRepository(connection);
                prodRepo = new ProductsRepository(connection);
                salesRepo = new SalesRepository(connection);

                Employees = empRepo.GetAll();
                Products = prodRepo.GetAll();
                Sales = salesRepo.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            dataGridEmployees.ItemsSource = Employees;
            dataGridProducts.ItemsSource = Products;

            this.Closing += MainWindow_Closing;
            buttonAddEmployees.Click += ButtonAddEmployees_Click;
            buttonLoadEmployees.Click += ButtonLoadEmployees_Click;

            //buttonLoadProducts.Click += ButtonLoadProducts_Click;
            buttonAddProducts.Click += ButtonAddProducts_Click;
            buttonAddSales.Click += ButtonAddSales_Click;

            SetUpProductInputs();
            SetUpSaleInputs();
        }

        private void UpdateGridDataSource(string tableName) 
        {
            dataSet.Clear();

            if(tableName == "Employees")
            {
                DataAdapterEmployees.Fill(dataSet, tableName);
                dataGridEmployees.ItemsSource = dataSet.Tables[tableName].DefaultView;
            }
            else  if (tableName == "Products")
            {
                DataAdapterEmployees.Fill(dataSet, tableName);
                dataGridProducts.ItemsSource = dataSet.Tables[tableName].DefaultView;
            }

            else if (tableName == "Sales")
            {
                DataAdapterEmployees.Fill(dataSet, tableName);
                dataGridSales.ItemsSource = dataSet.Tables[tableName].DefaultView;
            }
        }
        public static SqlDataAdapter GetEmployeesAdapter(SqlConnection conn)
        {
            string selectCommand = @"SELECT * FROM Employees";
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            return adapter;
        }

        public static SqlDataAdapter GetProductsAdapter(SqlConnection conn)
        {
            string selectCommand = @"SELECT * FROM Products";
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            return adapter;
        }

        public static SqlDataAdapter GetSalesAdapter(SqlConnection conn)
        {
            string selectCommand = @"SELECT * FROM Sales";
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            return adapter;
        }

        private void ButtonAddSales_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string customerName = textBoxCustomerInput.Text;
                int quantity = Convert.ToInt32(textBoxQuantity);
                int productId = 0;
                int employeeId = 0;

                if(comboBoxProducts.SelectedItem is Product)
                    productId = Convert.ToInt32(comboBoxProducts.SelectedItem as Product);

                if (comboBoxEmployees.SelectedItem is Product)
                    employeeId = Convert.ToInt32(comboBoxEmployees.SelectedItem as Product);

                salesRepo.Insert(new Sale
                {
                    CustomerName = customerName,
                    Quantity = quantity,
                    ProductInfo = new Product() { Id = productId},
                    EmployeeInfo = new Employee() { Id = employeeId }
                });

                Sales = salesRepo.GetAll();
                dataGridSales.ItemsSource = Sales;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAddProducts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prodRepo.Insert(Product.FromString
                    (
                        "0",
                        ProductInputs[0].Text,
                        ProductInputs[1].Text,
                        ProductInputs[2].Text,
                        ProductInputs[3].Text,
                        ProductInputs[4].Text
                    ));

                Products = prodRepo.GetAll();
                dataGridProducts.ItemsSource = Products;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonLoadProducts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Products = prodRepo.GetAll();
                dataGridProducts.ItemsSource = Products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void ButtonLoadEmployees_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employees = empRepo.GetAll();
                dataGridEmployees.ItemsSource = Employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ButtonAddEmployees_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                empRepo.Insert(new Employee()
                {
                    FirstName = textBoxFirstName.Text,
                    LastName = textBoxLastName.Text
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (connection != null)
                connection.Close();
        }

        private void SetUpProductInputs()
        {
            ProductInputs = new List<TextBox>();

            var temp = new Product();

            foreach (var prop in temp.GetType().GetProperties())
            {
                if (prop.Name == "Id") continue;

                var stackPanel = new StackPanel()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(5)
                };

                var textBlock = new TextBlock()
                {
                    Text = $"{prop.Name}: ",
                    Width = 100,
                };

                var textBox = new TextBox()
                {
                    Margin = new Thickness(2),
                    Width= 100
                };
                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(textBox);

                stackPanelProducts.Children.Add(stackPanel);
                ProductInputs.Add(textBox);
            }
        }

        private void SetUpSaleInputs()
        {
            var stackPanel1 = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(5)
            };

            textBoxCustomerInput = new TextBox()
            {
                Width = 100,
            };

            textBoxQuantity = new TextBox()
            {
                Margin = new Thickness(2),
                Width = 100
            };
            stackPanel1.Children.Add(textBoxCustomerInput);
            stackPanel1.Children.Add(textBoxQuantity);

            stackPanelProducts.Children.Add(stackPanel1);

            var stackPanel2 = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(5)
            };

            var textBlock2 = new TextBlock()
            {
                Width = 200,
            };

            var textBox2 = new TextBox()
            {
                Margin = new Thickness(2),
                Width = 200
            };
            stackPanel2.Children.Add(textBlock2);
            stackPanel2.Children.Add(textBox2);

            stackPanelSales.Children.Add(stackPanel2);

            comboBoxEmployees = new ComboBox();
            comboBoxEmployees.ItemsSource = Employees;

            comboBoxProducts = new ComboBox();
            comboBoxProducts.ItemsSource = Products;

            stackPanelSales.Children.Add(comboBoxEmployees);
            stackPanelSales.Children.Add(comboBoxProducts);
        }
    }
}