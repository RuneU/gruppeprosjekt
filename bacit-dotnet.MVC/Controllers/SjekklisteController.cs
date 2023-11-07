using bacit_dotnet.MVC.Models.ServiceOrdre;
using bacit_dotnet.MVC.Models.Sjekkliste;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Repositories;
using bacit_dotnet.MVC.Models;

namespace bacit_dotnet.MVC.Controllers
{
    public class SjekklisteController : Controller
    {
        private readonly CheckListRepository _checkListrepository;

        public SjekklisteController(CheckListRepository checkListrepository)
        {
            _checkListrepository = checkListrepository;
        }

        public IActionResult Index()
        {
            YourAction();
            var checkList = _checkListrepository.GetAll();
            return View("~/Views/Sjekkliste/Sjekkliste.cshtml");

        }
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

            _checkListrepository.Insert(Sjekkliste sjekkliste);

            // Return SJekkliste view
            return View("~/Views/Sjekkliste/Sjekkliste.cshtml");
        }
    }
}
