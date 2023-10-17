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
    public class KundeInfoController : Controller
    {
        static readonly List<KundeInformasjonViewModel> kunder = new();

        public ActionResult KundeInformasjon()
        {
            return View();  
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
        public ActionResult Display()
        { 
            return View(kunder); 
        }
    }
}
