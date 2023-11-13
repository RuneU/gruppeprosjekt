using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models.DineSaker;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using bacit_dotnet.MVC.Views.FormsMain;

namespace bacit_dotnet.MVC.Controllers
{

    public class HomeController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private readonly ServiceOrderRepository _serviceOrderRepository;

        public HomeController(CustomerRepository customerRepository, ServiceOrderRepository serviceOrderRepository)
        {
            _customerRepository = customerRepository;
            _serviceOrderRepository = serviceOrderRepository;
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

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {

                var s = "ineedabreakpoint";


            }


            return View("Index", model);
        }

        

        

        public IActionResult Search(string term)
        {
            ViewBag.Term = term;
            return View("Index");
        }
    }
}