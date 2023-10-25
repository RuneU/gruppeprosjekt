using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers;

public class AdminPageController : Controller
{
    // GET
    public IActionResult AdminPage()
    {
        return View();
    }
}