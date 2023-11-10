using bacit_dotnet.MVC.Models.Sjekkliste;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class SjekklisteController : Controller
    {

        public ActionResult Sjekkliste()
        {

            /*var model = new SjekklisteViewModel
            {
                DokNr = "",
                ServiceDato = "",
                GodkjentAv = "",
          

            }
           ;*/
            return View("~/Views/Sjekkliste/Sjekkliste.cshtml");
        }



       /* [HttpPost]

        public ActionResult Save(IFormCollection collection)
        {

            {
                return RedirectToAction(nameof(Sjekkliste));
            }
        }*/

    }
}
