using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class SjekklisteController : Controller
    {

        public ActionResult Sjekkliste()
        {
            return View();
        }



        [HttpPost]

        public ActionResult Save(IFormCollection collection)
        {

            {
                return RedirectToAction(nameof(Sjekkliste));
            }
        }

    }
}
