
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Diagnostics;
using bacit_dotnet.MVC.Models.DineSaker;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using bacit_dotnet.MVC.Views.FormsMain;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;

namespace bacit_dotnet.MVC.Controllers
{

    [Authorize]
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
                var query = "SELECT Customer.*, ServiceOrder.* FROM Customer INNER JOIN ServiceOrder ON Customer.CustomerID = ServiceOrder.CustomerID ";

               
                switch (searchBy)
                {
                    case "Sak.nr":
                        query += "WHERE Customer.CustomerID LIKE @SearchValue ";
                        break;
                    case "Navn":
                        query += "WHERE Customer.FirstName LIKE @SearchValue ";
                        break;
                    case "Telefon":
                        query += "WHERE Customer.PhoneNumber LIKE @SearchValue ";
                        break;
                    case "Date":
                        query += "WHERE ServiceOrder.DateReceived LIKE @SearchValue ";
                        break;
                    case "Status":
                        query += "WHERE ServiceOrder.Status LIKE @SearchValue ";
                        break;
                    default:
                        query += "WHERE Customer.FirstName LIKE @SearchValue ";
                        break;
                }

              
                

                var customers = dbConnection.Query<Customer>(query, new { SearchValue = $"%{searchValue}%" }).ToList();
                var serviceOrder = dbConnection.Query<ServiceOrder>(query, new { SearchValue = $"%{searchValue}%" }).ToList();

                dbConnection.Close();

                var viewModel = new HomeViewModel
                {
                    Customers = customers,
                    ServiceOrders = serviceOrder,
                    
                };

                return View("Index", viewModel);
            }
        }

    }


}




    