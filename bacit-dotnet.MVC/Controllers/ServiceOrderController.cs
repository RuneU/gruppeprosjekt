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
        public IActionResult ServiceOrder()
        {
            var model = new ServiceOrderViewModel
            {
                Mechanic = "rune",
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
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Save(ServiceOrderViewModel model) {
            if(ModelState.IsValid)
            {
                var s = "ineedabreakpoint";

            }
            return View("ServiceOrder", model);
        }
    }
}