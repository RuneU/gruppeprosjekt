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


        public void Insert(Customer customer)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            // Start a transaction in case you need to roll back if something goes wrong
            using var transaction = dbConnection.BeginTransaction();

            try
            {
                // Insert the Customer and get back the ID (if your table is set up to auto-increment the ID)
                var sql = "INSERT INTO Customer (FirstName, LastName, CustomerEmail, Adress, ZipCode, PhoneNumber, CustomerId) VALUES (@FirstName, @LastName, @CustomerEmail, @Adress, @ZipCode, @PhoneNumber, @CustomerId); SELECT LAST_INSERT_ID();";
                var customerId = dbConnection.Query<int>(sql, customer, transaction).Single();

                // Now you have the CustomerId and ServiceOrderId, you can handle additional logic as needed

                // If everything is fine, commit the transaction
                transaction.Commit();
            }
            catch
            {
                // Something went wrong, rollback
                transaction.Rollback();
                throw;
            }
        }

        public Customer GetById(int id)
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return dbConnection.Query<Customer>("SELECT * FROM Customer WHERE CustomerId = @CustomerId", new { CustomerId = id }).FirstOrDefault();
        }

        public bool Update(Customer customer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var affectedRows = dbConnection.Execute("UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, CustomerEmail = @CustomerEmail, Adress = @Adress, ZipCode = @ZipCode, PhoneNumber = @PhoneNumber WHERE CustomerId = @CustomerId", customer);
                return affectedRows > 0;
            }
        }



    }
}