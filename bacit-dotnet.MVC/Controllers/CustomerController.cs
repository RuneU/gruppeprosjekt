using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Views.FormsMain;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System;


namespace bacit_dotnet.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepository;
       
        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            

        }

     
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Debug.WriteLine($"Error in {state.Key}: {error.ErrorMessage}");
                    }
                }
                return View(customer);
            }

            _customerRepository.Insert(customer);
            return RedirectToAction("ServiceOrder", "ServiceOrder", new { CustomerID = customer.CustomerID });
        }

        public IActionResult Edit(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                // The model is not valid, return the same view with the current model to show validation errors
                return View(customer);
            }

            // If we got this far, everything is valid and we can update the customer
            _customerRepository.Update(customer);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Customer()
        {
            
            return View();
        }
    }
}