using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Repository
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public string GetAll()
        {
            string allData = string.Empty;

            SqlCommand cmd = new SqlCommand("GetALl", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                    allData += reader["Id"] + " " + reader["FoodName"] + " " + reader["FoodType"] + " " + reader["FoodColor"] + " " + reader["Сaloricity"] + '\n';

                return allData;
            }
        }

        public string GetName()
        {
            string allData = string.Empty;

            SqlCommand cmd = new SqlCommand("GetFoodName", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    allData += reader["FoodName"] + "\n";

                return allData;
            }
        }

        public string GetColor()
        {
            string allData = string.Empty;

            SqlCommand cmd = new SqlCommand("GetFoodColor", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    allData += reader["FoodColor"] + "\n";

                return allData;
            }
        }

        public decimal GetMaxCaloricity()
        {
            SqlCommand cmd = new SqlCommand("Procedure", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        public decimal GetMinCaloricity()
        {
            SqlCommand cmd = new SqlCommand("MinCaloricity", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        public decimal GetAVGCaloricity()
        {
            SqlCommand cmd = new SqlCommand("AVGCaloricity", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        public int QuantityVegetables()
        {
            SqlCommand cmd = new SqlCommand("QuantityV", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int QuantityFruits()
        {
            SqlCommand cmd = new SqlCommand("QuantityF", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int QuantityFVSpecifiedColor(string color)
        {
            SqlCommand cmd = new SqlCommand("QuantityFVSpecifiedColor", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@color", SqlDbType.NVarChar);
            parameter.Value = color;
            cmd.Parameters.Add(parameter);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public string QuantityFVAllColors()
        {
            string allData = string.Empty;
            SqlCommand cmd = new SqlCommand("QuantityFVAllColors", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string foodColor = reader["FoodColor"].ToString();
                    int quantity = (int)reader["Quantity"];
                    allData += $"{foodColor}: {quantity}\n";
                }

                return allData;
            }
        }

        public string FVMinCaloricity(decimal ccal)
        {
            string allData = string.Empty;
            SqlCommand cmd = new SqlCommand("FVMinCaloricity", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@ccal", SqlDbType.Decimal);
            parameter.Value = ccal;
            cmd.Parameters.Add(parameter);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    allData += reader["Id"] + " " + reader["FoodName"] + " " + reader["FoodType"] + " " + reader["FoodColor"] + " " + reader["Сaloricity"] + '\n';

                return allData;
            }
        }

        public string FVMaxCaloricity(decimal ccal)
        {
            string allData = string.Empty;
            SqlCommand cmd = new SqlCommand("FVMaxCaloricity", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@ccal", SqlDbType.Decimal);
            parameter.Value = ccal;
            cmd.Parameters.Add(parameter);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    allData += reader["Id"] + " " + reader["FoodName"] + " " + reader["FoodType"] + " " + reader["FoodColor"] + " " + reader["Сaloricity"] + '\n';

                return allData;
            }
        }

        public string FVRangeCaloricity(decimal min, decimal max)
        {
            string allData = string.Empty;
            SqlCommand cmd = new SqlCommand("CaloricityRange", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@min", SqlDbType.Decimal);
            parameter.Value = min;
            cmd.Parameters.Add(parameter);

            SqlParameter parameter1 = new SqlParameter("@max", SqlDbType.Decimal);
            parameter1.Value = max;
            cmd.Parameters.Add(parameter1);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    allData += reader["Id"] + " " + reader["FoodName"] + " " + reader["FoodType"] + " " + reader["FoodColor"] + " " + reader["Сaloricity"] + '\n';

                return allData;
            }
        }

        public string YellowOrRedColor()
        {
            string allData = string.Empty;
            SqlCommand cmd = new SqlCommand("YellowOrRedColor", _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    allData += reader["Id"] + " " + reader["FoodName"] + " " + reader["FoodType"] + " " + reader["FoodColor"] + " " + reader["Сaloricity"] + '\n';

                return allData;
            }
        }
    }
}