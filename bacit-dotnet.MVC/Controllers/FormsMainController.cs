using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Models.ServiceOrdre;
using bacit_dotnet.MVC.Views.FormsMain;

namespace bacit_dotnet.MVC.Controllers
{
    public class FormsMainController : Controller
    {
        public IActionResult ServiceOrdre()
        {
            var model = new ServiceOrderViewModel
            {
                Mechanic = "rune"
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
            return View("Serviceordre", model);
        }
    }
}