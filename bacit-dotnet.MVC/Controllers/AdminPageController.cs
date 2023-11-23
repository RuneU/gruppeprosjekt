using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers;

public class AdminPageController : Controller
{
    [Authorize]

    // GET
    public IActionResult AdminPage()
    {
        return View();
    }
}