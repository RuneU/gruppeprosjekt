using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Models.KundeInformasjon;
using bacit_dotnet.MVC.Views.FormsMain;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using bacit_dotnet.MVC.Models.ServiceOrdre;

namespace bacit_dotnet.MVC.Controllers
{
    public class KundeInformasjonController : Controller
    {
        

        public IActionResult KundeInformasjon()
        {
            var model = new KundeInformasjonViewModel
            {
                Fornavn = "rune",
                Etternavn = "",
                Email = "",
                Adresse = "",
                Postnummer = "",
            }
            ;
            return View(model);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Save(KundeInformasjonViewModel model)
        {
            if (ModelState.IsValid) 
            {
               
                var s = "ineedabreakpoint"; 
            }

            return View("KundeInformasjon", model);
        }
    }
}
