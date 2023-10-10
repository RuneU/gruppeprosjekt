
using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Models.Login;

namespace bacit_dotnet.MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var model = new LoginViewModel()
            {
                brukernavn = "",
                passord = ""
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Save(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var y = "ineedabreakpoint";
            }
            return View("Index", model);
        }

    }
}
