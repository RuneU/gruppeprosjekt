using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Views.FormsMain;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace bacit_dotnet.MVC.Controllers
{
    [Authorize] // This attribute restricts access to the entire `CustomerController` to only authenticated users.
                // This is a security measure to ensure that only authorized users can interact with customer-related actions.

    public class ServiceOrderController : Controller
    {

        private readonly ServiceOrderRepository _serviceOrderrepository;

        // Dependency injection is used here to ensure that the ServiceOrderController has access to a ServiceOrderRepository instance. 
        public ServiceOrderController(ServiceOrderRepository serviceOrderrepository)
        {
            _serviceOrderrepository = serviceOrderrepository;
        }

        // This action is responsible for rendering the initial view for creating or editing service orders.
        // It sets up necessary data, like the last customer ID and a new ServiceOrder object, and passes them to the view. 
        public IActionResult ServiceOrder()
        {
            YourAction();
            int lastCustomerID = _serviceOrderrepository.GetLastCustomerID();
            var serviceOrder = new ServiceOrder { CustomerID = lastCustomerID };

            var serviceOrders = _serviceOrderrepository.GetAll();

            return View("~/Views/ServiceOrder/ServiceOrder.cshtml", serviceOrder);
        }

        // This action redirects the user to the 'Edit' action of the 'Sjekkliste' controller with the specified CustomerID as a route parameter.
        public IActionResult RedirectToChecklist(int customerId)
        {
            
            return RedirectToAction("Edit", "Sjekkliste", new { CustomerID = customerId });
        }

        // This action is responsible for populating the StatusList ViewBag property with a list of SelectListItem objects representing different service order statuses.
        // It is used to render a dropdown list in the view for selecting the status.
        public IActionResult YourAction()
        {
            ViewBag.StatusList = new List<SelectListItem>
        {
        new SelectListItem { Value = "Ikke tildelt", Text = "Ikke tildelt" },
        new SelectListItem { Value = "Vent internt", Text = "På vent internt" },
        new SelectListItem { Value = "Vent eksternt", Text = "På vent eksternt" },
        new SelectListItem { Value = "Under arbeid", Text = "Under arbeid" },
        new SelectListItem { Value = "Lukket", Text = "Lukket" },
        };
            return PartialView("~/Views/ServiceOrder/StatusDropdown.cshtml");
        }

        // This action handles the HTTP GET request for creating a new service order.
        // It initializes a new ServiceOrder object with the specified CustomerID and renders the 'Create' view.
        public ActionResult Create(int customerId)
        {
            var serviceOrder = new ServiceOrder { CustomerID = customerId };
            return View(serviceOrder);
        }

        // This action handles the HTTP GET request for editing an existing service order.
        // It sets up necessary data, like the service order itself and the StatusList, and renders the 'Edit' view.
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

        // This action handles the HTTP POST request for creating a new service order.
        // It validates the model state, logs errors if any, inserts the service order into the repository, and redirects to the 'Sjekkliste' action.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceOrder serviceOrder) // validate model state, insert service order, and redirect to 'Sjekkliste' action
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

                return BadRequest(ModelState);
            }


            _serviceOrderrepository.Insert(serviceOrder);
            int customerId = serviceOrder.CustomerID;
            return RedirectToAction("Sjekkliste", "Sjekkliste", new { CustomerID = customerId });
        }

        // This action handles the HTTP POST request for updating an existing service order.
        // It validates the model state, updates the service order in the repository, and redirects based on the success or failure of the update operation.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceOrder serviceOrder) // update properties of 'toUpdate' with values from 'form'
        {
            if (!ModelState.IsValid)
            {
                return View(serviceOrder);
            }

           
            var existingServiceOrder = _serviceOrderrepository.GetServiceOrderByID(serviceOrder.ServiceOrderID);

            if (existingServiceOrder == null)
            {
                ModelState.AddModelError("", "Service Order ikke funnet.");
                return View(serviceOrder);
            }

            UpdateServiceOrderFromForm(existingServiceOrder, serviceOrder);

            bool updateSuccess = _serviceOrderrepository.Update(existingServiceOrder);
            if (updateSuccess)
            {
                return RedirectToAction("Index", "Home"); 
            }
            else
            {
                ModelState.AddModelError("", "Unable to save changes.");
                return View(serviceOrder);
            }
        }

        // This method is a helper function to update the properties of an existing ServiceOrder object (toUpdate) with
        // values from another ServiceOrder object (form). It centralizes the logic for updating service order properties.
        private void UpdateServiceOrderFromForm(ServiceOrder toUpdate, ServiceOrder form)
        {
            toUpdate.CreatedBy = form.CreatedBy;
            toUpdate.DateReceived = form.DateReceived;
            toUpdate.ModelYear = form.ModelYear;
            toUpdate.ProductType = form.ProductType;
            toUpdate.SerialNumber = form.SerialNumber;
            toUpdate.ServiceType = form.ServiceType;
            toUpdate.WhatIsAgreedWithCustomer = form.WhatIsAgreedWithCustomer;
            toUpdate.RepairDescription = form.RepairDescription;
            toUpdate.IncludedParts = form.IncludedParts;
            toUpdate.DateCompleted = form.DateCompleted;
            toUpdate.WorkingHours = form.WorkingHours;
            toUpdate.ReplacedPartsReturned = form.ReplacedPartsReturned;
            toUpdate.ShippingMethod = form.ShippingMethod;
            toUpdate.Status = form.Status;
            toUpdate.Subject = form.Subject;
            toUpdate.BookedServiceToWeek = form.BookedServiceToWeek;
            toUpdate.AgreedDeliveryDateWithCustomer = form.AgreedDeliveryDateWithCustomer;
        }

    }
}

