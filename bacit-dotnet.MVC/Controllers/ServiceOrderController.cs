using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Models.ServiceOrdre;
using bacit_dotnet.MVC.Views.FormsMain;

namespace bacit_dotnet.MVC.Controllers
{
    public class ServiceOrderController : Controller
    {
        public IActionResult Index()
        {
            /*var model = new ServiceOrderViewModel
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
            ;*/
            return View("~/Views/ServiceOrder/ServiceOrder.cshtml");
        }

        [HttpPost]
        public IActionResult Save(ServiceOrder model)
        {
            if (ModelState.IsValid)
            {
                var s = "ineedabreakpoint";

            }
            return View("ServiceOrder", model);
        }
    }
}