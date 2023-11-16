﻿
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Diagnostics;
using bacit_dotnet.MVC.Models.DineSaker;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using bacit_dotnet.MVC.Views.FormsMain;
using System.Data;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;

namespace bacit_dotnet.MVC.Controllers
{

    public class HomeController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private readonly ServiceOrderRepository _serviceOrderRepository;
        private readonly IConfiguration _config;

        
        public HomeController(CustomerRepository customerRepository, ServiceOrderRepository serviceOrderRepository, IConfiguration config)
        {
            _customerRepository = customerRepository;
            _serviceOrderRepository = serviceOrderRepository;
            _config = config;

        }

        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
    
                Customers = _customerRepository.GetAll(),
                ServiceOrders = _serviceOrderRepository.GetAll()
            };
            if (viewModel.Customers == null || viewModel.ServiceOrders == null)
            {
                
                viewModel.Customers = new List<Customer>();
                viewModel.ServiceOrders = new List<ServiceOrder>();
            }

            return View(viewModel);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Search(string searchBy, string searchValue)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                // Initialize the base query
                var query = "SELECT * FROM Customer WHERE ";

                // Adjust the query based on the search criteria selected
                switch (searchBy)
                {
                    case "Navn":
                        query += "FirstName LIKE @SearchValue";
                        break;
                    case "Telefon":
                        query += "PhoneNumber LIKE @SearchValue";
                        break;
                    case "Status":
                        // Assuming you have a status column in your Customers table
                        query += "Status LIKE @SearchValue";
                        break;
                    default:
                        // If no search type is selected, default to Name
                        query += "FirstName LIKE @SearchValue";
                        break;
                }
               
                var customers = dbConnection.Query<Customer>(query, new { SearchValue = $"%{searchValue}%" }).ToList();

                dbConnection.Close();

                var viewModel = new HomeViewModel
                {
                    Customers = customers,
                    
                };

                return View("Index", viewModel);
            }
        }

        // Your other actions...
    }


}




    