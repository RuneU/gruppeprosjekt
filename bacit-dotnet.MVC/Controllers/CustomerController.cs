using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Views.FormsMain;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Net;


namespace bacit_dotnet.MVC.Controllers
{
    [Authorize]

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


            customer.FirstName = WebUtility.HtmlEncode(customer.FirstName);
            customer.LastName = WebUtility.HtmlEncode(customer.LastName);
            customer.CustomerEmail = WebUtility.HtmlEncode(customer.CustomerEmail);
            customer.Adress = WebUtility.HtmlEncode(customer.Adress);
            customer.PhoneNumber = WebUtility.HtmlEncode(customer.PhoneNumber);
            customer.ZipCode = WebUtility.HtmlEncode(customer.ZipCode);

            int newCustomerId = _customerRepository.Insert(customer);
            return RedirectToAction("ServiceOrder", "ServiceOrder", new { CustomerID = newCustomerId });
        }

        public IActionResult Edit(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                
                return View(customer);
            }


            customer.FirstName = WebUtility.HtmlEncode(customer.FirstName);
            customer.LastName = WebUtility.HtmlEncode(customer.LastName);
            customer.CustomerEmail = WebUtility.HtmlEncode(customer.CustomerEmail);
            customer.Adress = WebUtility.HtmlEncode(customer.Adress);
            customer.PhoneNumber = WebUtility.HtmlEncode(customer.PhoneNumber);
            customer.ZipCode = WebUtility.HtmlEncode(customer.ZipCode);

            _customerRepository.Update(customer);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Customer()
        {
            
            return View();
        }
    }
}