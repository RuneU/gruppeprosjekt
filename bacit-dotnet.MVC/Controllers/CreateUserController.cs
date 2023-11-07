using bacit_dotnet.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers;

public class CreateUserController : Controller
{
    // GET
    public IActionResult CreateUser()
    {
        return View();
    }
}