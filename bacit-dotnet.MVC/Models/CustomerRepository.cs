﻿using Dapper;
using Microsoft.Extensions.Configuration;
//using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
            dbConnection.Execute("INSERT INTO Customer (FirstName, LastName, CustomerEmail, Adress, ZipCode, PhoneNumber) VALUES (@FirstName, @LastName, @CustomerEmail, @Adress, @ZipCode, @PhoneNumber)", customer);
        }

        public void CreateTable()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string createTableSql = @"
                CREATE TABLE IF NOT EXISTS MyTable (
                Id INT PRIMARY KEY,
                FirstName VARCHAR(255),
                LastName VARCHAR(255),
                )";

                dbConnection.Execute(createTableSql);
            }
        }
    }
}