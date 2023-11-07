using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Views.FormsMain;
using MySqlX.XDevAPI;
using Newtonsoft.Json;

namespace bacit_dotnet.MVC.Controllers
{
        public class CustomerController : Controller
        {
            private readonly CustomerRepository _customerRepository;

            public CustomerController(CustomerRepository customerrepository)
            {
                _customerRepository = customerrepository;
            }
            
            public IActionResult Customer()
            {
                var customers = _customerRepository.GetAll();
                return View();
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult CreateCustomerPerson(Customer customer)
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
                return RedirectToAction("Index");
            }
        }
    }
