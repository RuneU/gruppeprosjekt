using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Models.ServiceOrdre;
using bacit_dotnet.MVC.Views.FormsMain;
using NuGet.Protocol.Core.Types;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceOrderController : Controller
    {
        private readonly ServiceOrderRepository _serviceOrderrepository;

        public ServiceOrderController(ServiceOrderRepository serviceOrderrepository)
        {
            _serviceOrderrepository = serviceOrderrepository;
        }

        public IActionResult Index()
        {
            var serviceOrder = _serviceOrderrepository.GetAll();
            return View("~/Views/ServiceOrder/ServiceOrder.cshtml");
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

            // Return serviceOrder view
            return View("~/Views/ServiceOrder/ServiceOrder.cshtml");
        }

    }
}