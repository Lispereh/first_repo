using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ConsoleApp2.Repositories;
using System.Configuration;
using ConsoleApp2.Models;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "";
            SqlConnection connection = null;

            try
            {
                connectionString = ConfigurationManager
                                   .ConnectionStrings["MyConnString"]
                                   .ConnectionString;

                connection = new SqlConnection(connectionString);
                connection.Open();

                if(connection.State == ConnectionState.Open)
                    Console.WriteLine("Connected to Database");

                ProductsRepository productsRepository = new ProductsRepository(connection);
                List<Product> list = productsRepository.GetAll();

                SalesRepository salesRepository = new SalesRepository(connection);
                List<Sale> listSale = salesRepository.GetAll();

                // Вставка новых канцтоваров
                //productsRepository.Insert(new Product()
                //{
                //    ProductName = "Milk",
                //    ProductType = "Diery",
                //    Cost = 10.5m,
                //    Price = 30.4m,
                //    Quantity = 5
                //});

                Console.WriteLine("\n-------------- Канцтовары --------------\n");

                foreach (Product product in list)
                    Console.WriteLine(product);

                // Вставка новых менеджеров по продажам
                var er = new EmployeesRepository(connection);
                //er.Insert(new Employee()
                //{
                //    FirstName = "John",
                //    LastName = "Doe"
                //});

                List<Employee> le = er.GetAll();

                Console.WriteLine("\n\n-------------- Сотрудники --------------\n");
                foreach (Employee employee in le)
                    Console.WriteLine(employee);

                Console.WriteLine("\n\n-------------- Канцтовары после обновления информации о канцтоваре с ID = 3 --------------\n");
                productsRepository.Update(3, "Product Name Update", "Product Type Update", 12, 36, 3);

                foreach (Product product in list)
                    Console.WriteLine(product);

                Console.WriteLine("\n\n-------------- Сотрудники после обновления информации о сотруднике с ID = 1 --------------\n");
                er.Update(1, "First Name Update", "Last Name Update");

                foreach (Employee employee in le)
                    Console.WriteLine(employee);

                Console.WriteLine("\n\n-------------- Канцтовары после удаления канцтовара с ID = 3 --------------\n");
                productsRepository.Delete(3);

                foreach (Product product in list)
                    Console.WriteLine(product);

                Console.WriteLine("\n\n-------------- Сотрудники после удаления сотрудника с ID = 2 --------------\n");
                er.Delete(2);

                foreach (Employee employee in le)
                    Console.WriteLine(employee);

                Console.WriteLine("\n\n-------------- Bся информация о менеджере с наибольшим количеством продаж по количеству единиц --------------\n");
                Console.WriteLine(er.GetBestSeller());

                Console.WriteLine("\n\n-------------- Информация о фирме покупателе, которая купила на самую большую сумму --------------\n");
                Console.WriteLine(salesRepository.GetTopCustomerByTotalPurchase());




                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            { if (connection != null)
                    connection.Close();
            }
        }
    }
}