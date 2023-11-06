using Dapper;
using Microsoft.Extensions.Configuration;
//using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace bacit_dotnet.MVC.Models

{
    public class EmployeeRepository
    {
        private readonly IConfiguration _config;

        public EmployeeRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return dbConnection.Query<Employee>("SELECT * FROM Employee");
        }

        public void Insert(Employee employee)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            dbConnection.Execute("INSERT INTO People (FirstName, LastName, Email, Adress, ZipCode, PhoneNumber, Role) VALUES (@FirstName, @LastName, @Email, @Adress, @ZipCode, @PhoneNumber, @Role)", employee);
        }
    }
}