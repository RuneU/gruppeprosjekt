using bacit_dotnet.MVC.Models.Sjekkliste;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Repositories;
using bacit_dotnet.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.Encodings.Web;
using System.Net;

namespace bacit_dotnet.MVC.Controllers
{
    [Authorize] // This attribute restricts access to the entire `SjekklisteController` to only authenticated users.
                // This is a security measure to ensure that only authorized users can interact with Sjekklis-related actions.
    public class SjekklisteController : Controller
    {
        // Dependency injection is used here to ensure that the `SjekklisteController` has access to a `SjekklistRepository` instance.
        private readonly CheckListRepository _checkListrepository;


        public SjekklisteController(CheckListRepository checkListrepository)
        {
            _checkListrepository = checkListrepository;
        }

        // This action handles GET requests to create a new checklist associated with a customer.
        public IActionResult Create(int customerId)
        {
            var checklist = new SjekklisteViewModel { CustomerID = customerId };
            return View(checklist);
        }

        // This action handles GET requests to display a checklist for a specific customer.
        [HttpGet]
        public ActionResult Sjekkliste(int customerId)
        {
            var sjekklisteViewModel = new SjekklisteViewModel { CustomerID = customerId };
            var checkLists = _checkListrepository.GetAll();
            return View(sjekklisteViewModel);
        }

        // This action handles GET requests to edit a checklist associated with a customer
        [HttpGet]
        public ActionResult Edit(int customerId)
        {

            var checkList = _checkListrepository.GetCheckListByCustomerID(customerId);

            if (checkList == null)
            {
                checkList = new SjekklisteViewModel
                {
                    CustomerID = customerId
                };
            }

            return View(checkList);
        }

        // This action handles POST requests to create a new checklist.
        // It performs validation, encodes some properties, and inserts the checklist into the repository.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SjekklisteViewModel checkList, string msg)
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

            checkList.DokNr = WebUtility.HtmlEncode(checkList.DokNr);
            checkList.ApprovedBy = WebUtility.HtmlEncode(checkList.ApprovedBy);
            checkList.PressureTest = WebUtility.HtmlEncode(checkList.PressureTest);
            checkList.CheckFunctions = WebUtility.HtmlEncode(checkList.CheckFunctions);
            checkList.PullingPower = WebUtility.HtmlEncode(checkList.PullingPower);
            checkList.BrakePower = WebUtility.HtmlEncode(checkList.BrakePower);



            _checkListrepository.Insert(checkList);

            // Return SJekkliste view
            return View("~/Views/Sjekkliste/Sjekkliste.cshtml");
        }

        // This action handles POST requests to edit an existing checklist.
        // It performs validation, encodes some properties, retrieves the existing checklist, updates it,
        // and then redirects based on the success or failure of the update.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SjekklisteViewModel checkList)
        {
            if (!ModelState.IsValid)
            {
                return View(checkList);
            }

            checkList.DokNr = WebUtility.HtmlEncode(checkList.DokNr);
            checkList.ApprovedBy = WebUtility.HtmlEncode(checkList.ApprovedBy);
            checkList.PressureTest = WebUtility.HtmlEncode(checkList.PressureTest);
            checkList.CheckFunctions = WebUtility.HtmlEncode(checkList.CheckFunctions);
            checkList.PullingPower = WebUtility.HtmlEncode(checkList.PullingPower);
            checkList.BrakePower = WebUtility.HtmlEncode(checkList.BrakePower);

            var existingcheckList = _checkListrepository.GetCheckListByID(checkList.CheckListID);

            if (existingcheckList == null)
            {
                ModelState.AddModelError("", "Sjekkliste ble ikke funnet.");
                return View(checkList);
            }

            UpdateCheckListFromForm(existingcheckList, checkList);

            bool updateSuccess = _checkListrepository.Update(existingcheckList);
            if (updateSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Ikke tilgjenglig å endre på Sjekkliste.");
                return View(checkList);
            }
        }

        // This is a private method used to update properties of an existing checklist based on the values provided in the form.
        private void UpdateCheckListFromForm(SjekklisteViewModel toUpdate, SjekklisteViewModel form)
        {

            toUpdate.DokNr = form.DokNr;
            toUpdate.Date = form.Date;
            toUpdate.ApprovedBy = form.ApprovedBy;
            toUpdate.CheckClutch = form.CheckClutch;
            toUpdate.WearBrakes = form.WearBrakes;
            toUpdate.CheckDrums = form.CheckDrums;
            toUpdate.CheckPto = form.CheckPto;
            toUpdate.CheckChainTensioner = form.CheckChainTensioner;
            toUpdate.CheckWire = form.CheckWire;
            toUpdate.CheckPinionBearing = form.CheckPinionBearing;
            toUpdate.CheckSprocket = form.CheckSprocket;
            toUpdate.CheckHydraulicSylinder = form.CheckHydraulicSylinder;
            toUpdate.CheckHose = form.CheckHose;
            toUpdate.CheckHydraulicBlock = form.CheckHydraulicBlock;
            toUpdate.CheckOilTank = form.CheckOilTank;
            toUpdate.CheckOilBox = form.CheckOilBox;
            toUpdate.CheckRingCylinder = form.CheckRingCylinder;
            toUpdate.CheckBrakeCylinder = form.CheckBrakeCylinder;
            toUpdate.CheckWiring = form.CheckWiring;
            toUpdate.CheckRadio = form.CheckRadio;
            toUpdate.CheckButtonBox = form.CheckButtonBox;
            toUpdate.PressureTest = form.PressureTest;
            toUpdate.CheckFunctions = form.CheckFunctions;
            toUpdate.PullingPower = form.PullingPower;
            toUpdate.BrakePower = form.BrakePower;

        }

    }
}