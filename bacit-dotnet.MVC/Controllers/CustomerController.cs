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
    [Authorize] // This attribute restricts access to the entire `CustomerController` to only authenticated users.
                // This is a security measure to ensure that only authorized users can interact with customer-related actions.
    public class CustomerController : Controller
    {
        // Dependency injection is used here to ensure that the `CustomerController` has access to a `CustomerRepository` instance.
        // This promotes code maintainability, testability, and adheres to the principle of inversion of control.
        private readonly CustomerRepository _customerRepository;
        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        // This action handles the HTTP GET request for editing a customer. It retrieves the customer by ID and renders the 'Edit' view.
        [HttpGet]
        public IActionResult Edit(int id) // (retrieve customer by id and render the 'Edit' view)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        // This action handles the HTTP POST request for creating a new customer.
        // It validates the model state, logs errors if any, inserts the customer into the repository, and redirects to the 'ServiceOrder' action.
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
                        Debug.WriteLine($"Error in {state.Key}: {error.ErrorMessage}"); // validate model state, insert customer, and redirect to 'ServiceOrder' action
                    }
                }
                return BadRequest(ModelState);
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

        // This action handles the HTTP POST request for updating an existing customer.
        // It validates the model state, updates the customer in the repository, and redirects to the 'Index' action of the 'Home' controller.
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
            return RedirectToAction("Index", "Home");  // Validate model state, update customer, and redirect to 'Index' action of 'Home' controller
        }

        // This action renders the 'Customer' view.
        // It provides a clean separation between the controller logic and the view rendering, promoting maintainability.
        public IActionResult Customer()
        {
            
            return View();
        }
    }
}