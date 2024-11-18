using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Repositories
{
    internal class EmployeesRepository
    {
        private readonly SqlConnection _connection;

        public EmployeesRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<Employee> GetAll()
        {
            var list = new List<Employee>();
            string selectString = "SELECT * FROM Employees";

            SqlCommand cmd = new SqlCommand(selectString, _connection);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    list.Add(
                        Employee.FromString(Convert.ToString(reader[0]),
                                           Convert.ToString(reader[1]),
                                           Convert.ToString(reader[2]))
                        );
            }

            return list;
        }

        // Вставка новых менеджеров по продажам
        public int Insert(Employee employee)
        {
            string insertString = $"INSERT INTO Employees (FirstName, LastName) VALUES (@firstName, @lastName)";
            SqlCommand cmd = new SqlCommand(insertString, _connection);

            SqlParameter ParamFirstName = new SqlParameter();
            ParamFirstName.ParameterName = "@firstName";
            ParamFirstName.SqlDbType = System.Data.SqlDbType.NVarChar;
            ParamFirstName.Value = employee.FirstName;
            cmd.Parameters.Add(ParamFirstName);

            SqlParameter ParamLastName = new SqlParameter("@lastName", System.Data.SqlDbType.NVarChar);
            ParamLastName.Value = employee.LastName;
            cmd.Parameters.Add(ParamLastName);

            return cmd.ExecuteNonQuery();
        }

        public int Update(int id, string firstName, string lastName)
        {
            SqlCommand cmd = new SqlCommand("UpdateEmployees", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter ParamId = new SqlParameter("@id", System.Data.SqlDbType.Int);
            ParamId.Value = id;
            cmd.Parameters.Add(ParamId);

            SqlParameter ParamFirstName = new SqlParameter("@firstName", System.Data.SqlDbType.NVarChar);
            ParamFirstName.Value = firstName;
            cmd.Parameters.Add(ParamFirstName);

            SqlParameter ParamLastName = new SqlParameter("@lastName", System.Data.SqlDbType.NVarChar);
            ParamLastName.Value = lastName;
            cmd.Parameters.Add(ParamLastName);

            return cmd.ExecuteNonQuery();
        }

        public Employee GetEmployeeByID(int id)
        {
            Employee employee = null;
            SqlCommand cmd = new SqlCommand("GetEmployeeByID", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter ParamId = new SqlParameter("@id", System.Data.SqlDbType.Int);
            ParamId.Value = id;
            cmd.Parameters.Add(ParamId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read()) // Проверяем, есть ли данные
                {
                    employee = new Employee
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                }
            }

            return employee;
        }

        public int Delete(int id)
        {

            Employee employeeToDelete = GetEmployeeByID(id);

            if (employeeToDelete != null)
            {
                using (SqlCommand archiveCmd = new SqlCommand("INSERT INTO ArchivedEmployees (Id, FirstName, LastName) VALUES (@Id, @FirstName, @LastName)", _connection))
                {
                    archiveCmd.Parameters.AddWithValue("@Id", employeeToDelete.Id);
                    archiveCmd.Parameters.AddWithValue("@FirstName", employeeToDelete.FirstName);
                    archiveCmd.Parameters.AddWithValue("@LastName", employeeToDelete.LastName);

                    archiveCmd.ExecuteNonQuery();
                }


                SqlCommand cmd = new SqlCommand("DeleteEmployee", _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamId = new SqlParameter("@id", System.Data.SqlDbType.Int);
                ParamId.Value = id;
                cmd.Parameters.Add(ParamId);

                return cmd.ExecuteNonQuery();
            }

            return 0;
        }

        public Employee GetBestSeller()
        {
            Employee bestSeller = null;
            SqlCommand command = new SqlCommand("TheBestSeller", _connection);
            command.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    bestSeller = new Employee
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                }
            }

            return bestSeller;
        }
    }
}
