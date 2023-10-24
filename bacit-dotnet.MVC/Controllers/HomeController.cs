using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Repositories;
using bacit_dotnet.MVC.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models.DineSaker;

namespace bacit_dotnet.MVC.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
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
        public IActionResult Save(HomeIndexViewModel model)
        {
            if (ModelState.IsValid)
            {

                var s = "ineedabreakpoint";


            }


            return View("Index", model);
        }
        public IActionResult Search(string term)
        {
            ViewBag.Term = term;
            return View("Index");
        }
    }
}