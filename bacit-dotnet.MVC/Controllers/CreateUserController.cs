using bacit_dotnet.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers;

public class CreateUserController : Controller
{
    [Authorize]
    // GET
    public IActionResult CreateUser()
    {
        return View();
    }
}