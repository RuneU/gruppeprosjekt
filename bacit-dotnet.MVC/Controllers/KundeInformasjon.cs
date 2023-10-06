using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Models.KundeInformasjon;
using bacit_dotnet.MVC.Views.FormsMain;

namespace bacit_dotnet.MVC.Controllers
{
    public class FormsMainController : Controller
    {
        public IActionResult KundeInformasjon()
        {

            var model = new KundeInformasjonViewModel
            {
                Fornavn = "",
                Etternavn = "",
                Email = "",
                Adresse = "",
                Postnummer = "",

            }
          ;
            return View(model);
        }
        [HttpPost]
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
