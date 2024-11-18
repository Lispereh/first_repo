using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Repositories
{
    internal class SalesRepository
    {
        private readonly SqlConnection _connection;

        public SalesRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<Sale> GetAll()
        {
            var list = new List<Sale>();

            SqlCommand cmd = new SqlCommand(@"Procedure", _connection);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    list.Add(Sale.FromString(reader));
            }

            return list;
        }

        // Вставка новых продаж
        public int Insert(Sale sale)
        {
            string insertString = $"INSERT INTO Sales (ProductId, EmployeeId, CustomerName, Quantity) VALUES (@productId, @employeeId, @customerName, @quantity)";
            SqlCommand cmd = new SqlCommand(insertString, _connection);

            SqlParameter ParamProductId = new SqlParameter();
            ParamProductId.ParameterName = "@productId";
            ParamProductId.SqlDbType = System.Data.SqlDbType.NVarChar;
            ParamProductId.Value = sale.ProductInfo.Id;
            cmd.Parameters.Add(ParamProductId);

            SqlParameter ParamEmployeeId = new SqlParameter();
            ParamEmployeeId.ParameterName = "@employeeId";
            ParamEmployeeId.SqlDbType = System.Data.SqlDbType.NVarChar;
            ParamEmployeeId.Value = sale.EmployeeInfo.Id;
            cmd.Parameters.Add(ParamEmployeeId);

            SqlParameter ParamCustomersName = new SqlParameter("@customerName", System.Data.SqlDbType.NVarChar);
            ParamCustomersName.Value = sale.CustomerName;
            cmd.Parameters.Add(ParamCustomersName);

            SqlParameter ParamQuantity = new SqlParameter("@quantity", System.Data.SqlDbType.NVarChar);
            ParamQuantity.Value = sale.Quantity;
            cmd.Parameters.Add(ParamQuantity);

            return cmd.ExecuteNonQuery();
        }

        public string GetTopCustomerByTotalPurchase()
        {
            string allData = string.Empty;

            SqlCommand cmd = new SqlCommand("DeleteProduct", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        allData += reader[i].ToString() + " ";
                    }
                }
            }

            return allData;
        }
    }
}