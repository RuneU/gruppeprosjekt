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
            var serviceOrder = _serviceOrderrepository.GetAll();
            return View();

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




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateServiceOrder(ServiceOrder serviceOrder)
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
    }

}