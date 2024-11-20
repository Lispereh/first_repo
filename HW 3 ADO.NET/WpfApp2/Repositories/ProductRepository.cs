using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Repositories
{
    public class ProductsRepository
    {
        private readonly SqlConnection _connection;

        public ProductsRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public ObservableCollection<Product> GetAll()
        {
            var list = new ObservableCollection<Product>();
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

        // 
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
    }
}