using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Views.FormsMain;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bacit_dotnet.MVC.Controllers
{
    [Authorize]

    public class ServiceOrderController : Controller
    {

        private readonly ServiceOrderRepository _serviceOrderrepository;

        public ServiceOrderController(ServiceOrderRepository serviceOrderrepository)
        {
            _serviceOrderrepository = serviceOrderrepository;
        }

        public IActionResult ServiceOrder()
        {
            YourAction();
            int lastCustomerID = _serviceOrderrepository.GetLastCustomerID();
            var serviceOrder = new ServiceOrder { CustomerID = lastCustomerID };

            var serviceOrders = _serviceOrderrepository.GetAll();

            return View("~/Views/ServiceOrder/ServiceOrder.cshtml", serviceOrder);
        }





        public IActionResult YourAction()
        {
            ViewBag.StatusList = new List<SelectListItem>
        {
        new SelectListItem { Value = "Ikke tildelt", Text = "Ikke tildelt" },
        new SelectListItem { Value = "Vent internt", Text = "På vent internt" },
        new SelectListItem { Value = "Vent eksternt", Text = "På vent eksternt" },
        new SelectListItem { Value = "UnderArbeid", Text = "Under arbeid" },
        new SelectListItem { Value = "Lukket", Text = "Lukket" },
        };
            return PartialView("~/Views/ServiceOrder/StatusDropdown.cshtml");
        }

        public ActionResult Create(int customerId)
        {
            var serviceOrder = new ServiceOrder { CustomerID = customerId };
            return View(serviceOrder);
        }

        [HttpGet]
        public ActionResult Edit(int customerId)
        {
            YourAction();
            var serviceOrder = _serviceOrderrepository.GetServiceOrderByCustomerID(customerId);

            if (serviceOrder == null)
            {
                serviceOrder = new ServiceOrder
                {
                    CustomerID = customerId
                };
            }

            return View(serviceOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ServiceOrder serviceOrder)
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

                // Return a 400 Bad Request status code for invalid input
                return BadRequest(ModelState);
            }

            _serviceOrderrepository.Insert(serviceOrder);
            return View("~/Views/ServiceOrder/ServiceOrder.cshtml");
        }

        public IActionResult Edit(ServiceOrder serviceOrder)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    if (state.Errors.Any())
                    {
                        foreach (var error in state.Errors)
                        {
                            
                            Debug.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                        }
                    }
                }

                
                return View(serviceOrder);
            }
            bool updateSuccess = _serviceOrderrepository.Update(serviceOrder);
            if (updateSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View(serviceOrder);
            }
        }
    }
}

