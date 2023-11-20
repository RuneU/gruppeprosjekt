using bacit_dotnet;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Views.FormsMain;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bacit_dotnet.MVC.Controllers
{
    [Authorize]

    public class CreateEmployeeController : Controller
    {
        private readonly EmployeeRepository _employeerepository;

        public CreateEmployeeController(EmployeeRepository employeerepository)
        {
            _employeerepository = employeerepository;
        }

        public IActionResult Index()
        {
            RoleList();
            var employee = _employeerepository.GetAll();
            return View("~/Views/CreateEmployee/CreateEmployee.cshtml");

        }

        public IActionResult RoleList()
        {
            ViewBag.RoleList = new List<SelectListItem>
    {
        new SelectListItem { Value = "Saksbehandler", Text = "Saksbehandler" },
         new SelectListItem { Value = "Mekaniker", Text = "Mekaniker" },
        new SelectListItem { Value = "Administrator", Text = "Administrator" },

        // Legg til flere statusalternativer om nødvendig
    };
            return PartialView("~/Views/CreateEmployee/RoleDropdown.cshtml");
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmployee(Employee employee)
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

            _employeerepository.Insert(employee);

            // Return serviceOrder view
            return View("~/Views/CreateEmployee/CreateEmployee.cshtml");
        }
    }

}
