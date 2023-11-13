using Dapper;
using Microsoft.Extensions.Configuration;
//using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;

namespace bacit_dotnet.MVC.Models

{
    public class CustomerRepository
    {
        private readonly IConfiguration _config;

        public CustomerRepository(IConfiguration config)
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

        public IEnumerable<Customer> GetAll()
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return dbConnection.Query<Customer>("SELECT * FROM Customer");
        }


        public int Insert(Customer customer)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            string insertQuery = @"
            INSERT INTO Customer (FirstName, LastName, CustomerEmail, Adress, ZipCode, PhoneNumber) 
            VALUES (@FirstName, @LastName, @CustomerEmail, @Adress, @ZipCode, @PhoneNumber);
            SELECT LAST_INSERT_ID();";

            int newCustomerId = dbConnection.Query<int>(insertQuery, customer).Single();
            return newCustomerId;
        }

        public Customer GetById(int id)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return dbConnection.Query<Customer>("SELECT * FROM Customer WHERE CustomerID = @CustomerID", new { CustomerID = id }).FirstOrDefault();

        }

        public bool Update(Customer customer)
        {

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var affectedRows = dbConnection.Execute("UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, CustomerEmail = @CustomerEmail, Adress = @Adress, ZipCode = @ZipCode, PhoneNumber = @PhoneNumber WHERE CustomerID = @CustomerID", customer);
                return affectedRows > 0;
            }
        }



    }
}