using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Models;

namespace ConsoleApp2.Repositories
{
    internal class ProductsRepository
    {
        private readonly SqlConnection _connection;

        public ProductsRepository(SqlConnection connection)
        {
            _connection= connection;
        }

        public List<Product> GetAll()
        {
            var list = new List<Product>();
            string selectString = "SELECT * FROM Products";

            SqlCommand cmd = new SqlCommand(selectString, _connection);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    list.Add(
                        Product.FromString(Convert.ToString(reader[0]),
                                           Convert.ToString(reader[1]),
                                           Convert.ToString(reader[2]),
                                           Convert.ToString(reader[3]),
                                           Convert.ToString(reader[4]),
                                           Convert.ToString(reader[5]))
                        );
            }

            return list;
        }

        // Вставка новых канцтоваров
        public int Insert(Product product)
        {
            string insertString = $"INSERT INTO Products (ProductName, ProductType, Cost, Price, Quantity)" +
                                  $"VALUES (@productName, @productType, @cost, @price, @quantity)";
            SqlCommand cmd = new SqlCommand(insertString, _connection);

            SqlParameter ParamProductName = new SqlParameter();
            ParamProductName.ParameterName = "@productName";
            ParamProductName.SqlDbType = System.Data.SqlDbType.NVarChar;
            ParamProductName.Value = product.ProductName;
            cmd.Parameters.Add(ParamProductName);

            SqlParameter ParamProductType = new SqlParameter("@productType", System.Data.SqlDbType.NVarChar);
            ParamProductType.Value = product.ProductType;
            cmd.Parameters.Add(ParamProductType);

            SqlParameter ParamCost = new SqlParameter("@cost", System.Data.SqlDbType.Decimal);
            ParamCost.Value = product.Cost;
            cmd.Parameters.Add(ParamCost);

            SqlParameter ParamPrice = new SqlParameter("@price", System.Data.SqlDbType.Decimal);
            ParamPrice.Value = product.Price;
            cmd.Parameters.Add(ParamPrice);

            SqlParameter ParamQuantity = new SqlParameter("@quantity", System.Data.SqlDbType.Int);
            ParamQuantity.Value = product.Quantity;
            cmd.Parameters.Add(ParamQuantity);

            return cmd.ExecuteNonQuery();
        }

        public int Update(int id, string productName, string productType, decimal cost, decimal price, int quantity)
        {
            SqlCommand cmd = new SqlCommand("UpdateProduct", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter ParamId = new SqlParameter("@id", System.Data.SqlDbType.Int);
            ParamId.Value = id;
            cmd.Parameters.Add(ParamId);

            SqlParameter ParamProductName = new SqlParameter("@productName", System.Data.SqlDbType.NVarChar);
            ParamProductName.Value = productName;
            cmd.Parameters.Add(ParamProductName);

            SqlParameter ParamProductType = new SqlParameter("@productType", System.Data.SqlDbType.NVarChar);
            ParamProductType.Value = productType;
            cmd.Parameters.Add(ParamProductType);

            SqlParameter ParamCost = new SqlParameter("@cost", System.Data.SqlDbType.Decimal);
            ParamCost.Value = cost;
            cmd.Parameters.Add(ParamCost);

            SqlParameter ParamPrice = new SqlParameter("@price", System.Data.SqlDbType.Decimal);
            ParamPrice.Value = price;
            cmd.Parameters.Add(ParamPrice);

            SqlParameter ParamQuantity = new SqlParameter("@quantity", System.Data.SqlDbType.Int);
            ParamQuantity.Value = quantity;
            cmd.Parameters.Add(ParamQuantity);

            return cmd.ExecuteNonQuery();
        }

        public Product GetProductByID(int id)
        {
            Product product = null;
            SqlCommand cmd = new SqlCommand("GetProductByID", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter ParamId = new SqlParameter("@id", System.Data.SqlDbType.Int);
            ParamId.Value = id;
            cmd.Parameters.Add(ParamId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read()) // Проверяем, есть ли данные
                {
                    product = new Product
                    {
                        Id = (int)reader["Id"],
                        ProductName = reader["ProductName"].ToString(),
                        ProductType = reader["ProductType"].ToString(),
                        Cost = (decimal)reader["Cost"],
                        Price = (decimal)reader["Price"],
                        Quantity = (int)reader["Quantity"]
                    };
                }
            }

            return product;
        }

        public int Delete(int id)
        {
            Product productToDelete = GetProductByID(id);
            if (productToDelete != null)
            {
                using (SqlCommand archiveCmd = new SqlCommand("INSERT INTO ArchivedProducts (Id, ProductName, ProductType, Cost, Price, Quantity) VALUES (@Id, @ProductName, @ProductType, @Cost, @Price, @Quantity)", _connection))
                {
                    archiveCmd.Parameters.AddWithValue("@Id", productToDelete.Id);
                    archiveCmd.Parameters.AddWithValue("@ProductName", productToDelete.ProductName);
                    archiveCmd.Parameters.AddWithValue("@ProductType", productToDelete.ProductType);
                    archiveCmd.Parameters.AddWithValue("@Cost", productToDelete.Cost);
                    archiveCmd.Parameters.AddWithValue("@Price", productToDelete.Price);
                    archiveCmd.Parameters.AddWithValue("@Quantity", productToDelete.Quantity);

                    archiveCmd.ExecuteNonQuery();
                }

                SqlCommand cmd = new SqlCommand("DeleteProduct", _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamId = new SqlParameter("@id", System.Data.SqlDbType.Int);
                ParamId.Value = id;
                cmd.Parameters.Add(ParamId);

                return cmd.ExecuteNonQuery();
            }

            return 0;
        }
    }
}