using bacit_dotnet.MVC.Models.KundeInformasjon;
using bacit_dotnet.MVC.Models.ServiceOrdre;
using bacit_dotnet.MVC.Models.Sjekkliste;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public IActionResult CreateCheckList(Sjekkliste sjekkliste)
        {
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Debug.WriteLine($"Error in {state.Key}: {error.ErrorMessage}");
                    }
                }

                // Return a 400 Bad Request status code for invalid input
                return BadRequest(ModelState);
            }

            _CheckListRepository.Insert(Sjekkliste sjekkliste);

            // Return SJekkliste view
            return View("~/Views/Sjekkliste/Sjekkliste.cshtml");
        }
    }
}
