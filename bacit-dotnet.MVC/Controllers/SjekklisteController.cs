using bacit_dotnet.MVC.Models.ServiceOrdre;
using bacit_dotnet.MVC.Models.Sjekkliste;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bacit_dotnet.MVC.Controllers
{
    public class SjekklisteController : Controller
    {

        public ActionResult Sjekkliste()
        {

            var model = new SjekklisteViewModel
            {
                DokNr = "",
                Date = "",
                ApprovedBy = "",
                CheckClutch = "",
               // CheckStorage = "",
                CheckPto = "",
                CheckChainTensioner = "",
                CheckWire = "",
                CheckPinionStorage = "",
                CheckSprocket = "",
                //CheckHydraulic = "",
                CheckHose = "",
                CheckHydraulicBlock = "",
                CheckOilTank = "",
                CheckOilBox = "",
                CheckRingCylinder = "",
                //CheckBrakeCylinder = "",
                CheckWiring = "",
                CheckRadio = "",
                CheckButtonBox = "",
                CheckFunctions = "",
                PullingPower = "",
                BrakePower = "",

            }
           ;
            return View(model);
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
