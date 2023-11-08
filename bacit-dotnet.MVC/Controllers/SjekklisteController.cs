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
        private readonly CheckListRepository _checkListRepository;

        public SjekklisteController(CheckListRepository checkListRepository)
        {
            _checkListRepository = checkListRepository;
        }

        public ActionResult Sjekkliste()
        {
            var sjekklisteViewModel = new SjekklisteViewModel();
            return View(sjekklisteViewModel);
        }

        [HttpPost]
        public IActionResult CreateCheckList(SjekklisteViewModel sjekkliste)
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

            // Assuming you have a CheckListRepository that can save the sjekkliste to the database
            _checkListRepository.Insert(sjekkliste);

            // Redirect to a success or result view
            return RedirectToAction("Sjekkliste"); // Or, you can redirect to a different view as needed
        }
    }
}
