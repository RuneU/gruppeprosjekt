using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Views.FormsMain;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bacit_dotnet.MVC.Controllers
{
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
        // Legg til flere statusalternativer om nødvendig
        };
            return PartialView("~/Views/ServiceOrder/StatusDropdown.cshtml");
        }

        public ActionResult Create(int customerId)
        {
            var serviceOrder = new ServiceOrder { CustomerID = customerId };
            return View(serviceOrder);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceOrder serviceOrder)
        {
            if (ModelState.IsValid)
            {
                _serviceOrderrepository.Insert(serviceOrder);
                // Redirect to an appropriate action, such as the details view of the newly created service order
                return RedirectToAction("Details", new { id = serviceOrder.ServiceOrderID });
            }

            // If model state is not valid, return to the view with the current data
            return View(serviceOrder);
        }
    }

}