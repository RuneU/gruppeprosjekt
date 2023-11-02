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
        /*public IActionResult ServiceOrder()
        {
            var model = new ServiceOrderViewModel
            {
                Mechanic = "",
                OpprettetAv = "",
                Ordrenummer = 0,
                MottaDato = "",
                AArsmodell = 1939,
                hvaErAvtaltMedKunde = "",
                Reperasjonsbeskrivelse = "",
                MedgåtteDeler = "",
                Arbeidstimer = 0,
                FerdigstiltDato = "",
                UtskriftDelerRetunert = "",
                Forsendelsemåte = "",
                SignaturKunde = "",
                SignaturReperatoer = "",




            }
            ;
            return View("~/Views/ServiceOrder/ServiceOrder.cshtml");
        }*/

        /*[HttpPost]
        public IActionResult Save(ServiceOrder model)
        {
            if (ModelState.IsValid)
            {
                var s = "ineedabreakpoint";

            }
            return View("ServiceOrder", model);
        }*/
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public IActionResult Create(ServiceOrder serviceOrder)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(serviceOrder);
                return RedirectToAction("Index");
            }
            return View(serviceOrder);
        }*/
        /* public IActionResult CreateServiceOrder(ServiceOrder serviceOrder)
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


                 return View(serviceOrder);
             }

             _serviceOrderrepository.Insert(serviceOrder);
             return RedirectToAction("Index");
         }*/
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

            // Return a 200 OK status code for successful creation
            return View("~/Views/ServiceOrder/ServiceOrder.cshtml");
        }

    }
}