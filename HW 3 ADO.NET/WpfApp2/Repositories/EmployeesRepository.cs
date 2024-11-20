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
    public class EmployeesRepository
    {
        private readonly SqlConnection _connection;

        public EmployeesRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public ObservableCollection<Employee> GetAll()
        {
            var list = new ObservableCollection<Employee>();
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
    }
}