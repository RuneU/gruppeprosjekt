using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Data.SqlClient;

namespace bacit_dotnet.MVC.Models
{
    public class HomeRepository
    {
        private readonly IConfiguration _config;

        public HomeRepository(IConfiguration config)
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

        public List<HomeViewModel> SearchCustomers(string searchQuery)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = @"
    SELECT FirstName, LastName
    FROM Customer 
    WHERE FirstName LIKE @SearchPattern OR LastName LIKE @SearchPattern";
                var filteredCustomers = dbConnection.Query<HomeViewModel>(query, new { SearchPattern = "%" + searchQuery + "%" }).ToList();
                dbConnection.Close();
                return filteredCustomers;
            }
        }

    }

}