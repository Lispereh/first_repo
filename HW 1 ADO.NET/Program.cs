using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = null;
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;
                                           Initial Catalog=VegetablesAndFruits;
                                           Integrated Security=True;Connect Timeout=30;
                                           Encrypt=False;");


            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                    Console.WriteLine("Подключение к БД успешно");

                Repository repository = new Repository(connection);
                
                Console.WriteLine("\n---------- Отображение всей информации из таблицы с овощами и фруктами ----------");
                Console.WriteLine(repository.GetAll());

                Console.WriteLine("\n---------- Отображение всех названий овощей и фруктов ----------");
                Console.WriteLine(repository.GetName());

                Console.WriteLine("\n---------- Отображение всех цветов ----------");
                Console.WriteLine(repository.GetColor());

                Console.WriteLine("\n---------- Показать максимальную калорийность ----------");
                Console.WriteLine(repository.GetMaxCaloricity());

                Console.WriteLine("\n---------- Показать минимальную калорийность ----------");
                Console.WriteLine(repository.GetMinCaloricity());

                Console.WriteLine("\n---------- Показать среднюю калорийность ----------");
                Console.WriteLine(repository.GetAVGCaloricity());

                Console.WriteLine("\n---------- Показать количество овощей ----------");
                Console.WriteLine(repository.QuantityVegetables());

                Console.WriteLine("\n---------- Показать количество фруктов ----------");
                Console.WriteLine(repository.QuantityFruits());

                Console.WriteLine("\n---------- Показать количество фруктов и овощей зелёного цвета ----------");
                Console.WriteLine(repository.QuantityFVSpecifiedColor("Зелёный"));

                Console.WriteLine("\n---------- Показать количество фруктов и овощей каждого цвета ----------");
                Console.WriteLine(repository.QuantityFVAllColors());

                Console.WriteLine("\n---------- Показать овощи и фрукты с калорийностью ниже 20 ----------");
                Console.WriteLine(repository.FVMinCaloricity(20));

                Console.WriteLine("\n---------- Показать овощи и фрукты с калорийностью выше 20 ----------");
                Console.WriteLine(repository.FVMaxCaloricity(20));

                Console.WriteLine("\n---------- Показать овощи и фрукты с калорийностью в диапазоне от 10 до 30 ----------");
                Console.WriteLine(repository.FVRangeCaloricity(10, 30));

                Console.WriteLine("\n---------- Показать овощи и фрукты, у которых цвет желтый или красный ----------");
                Console.WriteLine(repository.YellowOrRedColor());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            Console.ReadKey();
        }
    }
}