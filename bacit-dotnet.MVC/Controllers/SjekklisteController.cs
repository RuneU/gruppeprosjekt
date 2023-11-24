using bacit_dotnet.MVC.Models.Sjekkliste;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Repositories;
using bacit_dotnet.MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace bacit_dotnet.MVC.Controllers
{
    [Authorize]
    public class SjekklisteController : Controller
    {
        private readonly CheckListRepository _checkListrepository;


        public SjekklisteController(CheckListRepository checkListrepository)
        {
            _checkListrepository = checkListrepository;
        }

        public IActionResult Create(int customerId)
        {
            var checklist = new SjekklisteViewModel { CustomerID = customerId };
            return View(checklist);
        }

        [HttpGet]
        public ActionResult Sjekkliste(int customerId)
        {
            
            var sjekklisteViewModel = new SjekklisteViewModel { CustomerID = customerId };
            var checkLists = _checkListrepository.GetAll();


            return View(sjekklisteViewModel);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SjekklisteViewModel sjekkliste)
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

            _checkListrepository.Insert(sjekkliste);

            // Return SJekkliste view
            return View("~/Views/Sjekkliste/Sjekkliste.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public ActionResult Edit(SjekklisteViewModel checkList)
        {
            if (!ModelState.IsValid)
            {
                return View(checkList);
            }

            bool updateSuccess = _checkListrepository.Update(checkList);
            if (updateSuccess)
            {
                return RedirectToAction("Index", "Home"); // Or wherever you want to redirect after successful update
            }
            else
            {
                ModelState.AddModelError("", "Unable to update the checklist.");
                return View(checkList);
            }
        }*/

        public ActionResult Edit(SjekklisteViewModel checkList)
        {
            if (!ModelState.IsValid)
            {
                return View(checkList);
            }

            
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