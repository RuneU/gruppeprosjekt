using bacit_dotnet.MVC.Models.DineSaker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class DineSakerController : Controller
    {
        [Authorize]
        public IActionResult DineSaker()
        {
            var model = new DineSakerViewModel
                {
                    Saksnummer = "",
                    Navn = "",
                    Emne = "",
                    Dato = "",
                    Status = "",
                }
                ;
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(DineSakerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var s = "ineedabreakpoint";
            }


            return View("DineSaker", model);
        }


        public IActionResult Search(string term)
        {
            ViewBag.Term = term;
            return View("DineSaker");
        }
    }
}