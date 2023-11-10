using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models.DineSaker;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var customers = _customerRepository.GetAll();
            return View(customers);
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