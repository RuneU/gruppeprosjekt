using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Views.FormsMain;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

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

        public IActionResult RedirectToChecklist(int customerId)
        {
            
            return RedirectToAction("Edit", "Sjekkliste", new { CustomerID = customerId });
        }

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

                
                return BadRequest(ModelState);
            }
            // XXS beskyttelse for DOM-basert angrep
            serviceOrder.CreatedBy = WebUtility.HtmlEncode(serviceOrder.CreatedBy);
            serviceOrder.ModelYear = WebUtility.HtmlEncode(serviceOrder.ModelYear);
            serviceOrder.ProductType = WebUtility.HtmlEncode(serviceOrder.ProductType);
            serviceOrder.SerialNumber = WebUtility.HtmlEncode(serviceOrder.SerialNumber);
            serviceOrder.ServiceType = WebUtility.HtmlEncode(serviceOrder.ServiceType);
            serviceOrder.WhatIsAgreedWithCustomer = WebUtility.HtmlEncode(serviceOrder.WhatIsAgreedWithCustomer);
            serviceOrder.RepairDescription = WebUtility.HtmlEncode(serviceOrder.RepairDescription);
            serviceOrder.IncludedParts = WebUtility.HtmlEncode(serviceOrder.IncludedParts);
            serviceOrder.ReplacedPartsReturned = WebUtility.HtmlEncode(serviceOrder.ReplacedPartsReturned);
            serviceOrder.ShippingMethod = WebUtility.HtmlEncode(serviceOrder.ShippingMethod);
            serviceOrder.Status = WebUtility.HtmlEncode(serviceOrder.Status);
            serviceOrder.Subject = WebUtility.HtmlEncode(serviceOrder.Subject);
            serviceOrder.BookedServiceToWeek = WebUtility.HtmlEncode(serviceOrder.BookedServiceToWeek);
        
            _serviceOrderrepository.Insert(serviceOrder);
            int customerId = serviceOrder.CustomerID;
            return RedirectToAction("Sjekkliste", "Sjekkliste", new { CustomerID = customerId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Edit(ServiceOrder serviceOrder)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceOrder);
            }

            serviceOrder.CreatedBy = WebUtility.HtmlEncode(serviceOrder.CreatedBy);
            serviceOrder.ModelYear = WebUtility.HtmlEncode(serviceOrder.ModelYear);
            serviceOrder.ProductType = WebUtility.HtmlEncode(serviceOrder.ProductType);
            serviceOrder.SerialNumber = WebUtility.HtmlEncode(serviceOrder.SerialNumber);
            serviceOrder.ServiceType = WebUtility.HtmlEncode(serviceOrder.ServiceType);
            serviceOrder.WhatIsAgreedWithCustomer = WebUtility.HtmlEncode(serviceOrder.WhatIsAgreedWithCustomer);
            serviceOrder.RepairDescription = WebUtility.HtmlEncode(serviceOrder.RepairDescription);
            serviceOrder.IncludedParts = WebUtility.HtmlEncode(serviceOrder.IncludedParts);
            serviceOrder.ReplacedPartsReturned = WebUtility.HtmlEncode(serviceOrder.ReplacedPartsReturned);
            serviceOrder.ShippingMethod = WebUtility.HtmlEncode(serviceOrder.ShippingMethod);
            serviceOrder.Status = WebUtility.HtmlEncode(serviceOrder.Status);
            serviceOrder.Subject = WebUtility.HtmlEncode(serviceOrder.Subject);
            serviceOrder.BookedServiceToWeek = WebUtility.HtmlEncode(serviceOrder.BookedServiceToWeek);

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

