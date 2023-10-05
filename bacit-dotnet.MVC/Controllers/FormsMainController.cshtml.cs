using bacit_dotnet.MVC.Models.KundeInformasjon;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class FormsMainController : Controller
    {
        public IActionResult KundeInformasjonModel()
        {
            var model = new KundeInformasjonViewModel
            {
                Mechanic = "rune"
            }
            ;
            return View(model);


        }
    }
}



