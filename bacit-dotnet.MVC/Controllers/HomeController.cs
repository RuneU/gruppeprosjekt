using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Repositories;
using bacit_dotnet.MVC.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models.DineSaker;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bacit_dotnet.MVC.Controllers
{

    public class HomeController : Controller
    {
        private readonly PersonRepository _personRepository;

        public HomeController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            var people = _personRepository.GetAll();
            return View(people);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult KundeInformasjon()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(HomeIndexViewModel model)
        {
            if (ModelState.IsValid)
            {

                var s = "ineedabreakpoint";


            }


            return View("Index", model);
        }

        public IActionResult CreatePerson(Person person)
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

                
                return View(person);
            }

            _personRepository.Insert(person);
            return RedirectToAction("Index");
        }

        

        public IActionResult Search(string term)
        {
            ViewBag.Term = term;
            return View("Index");
        }
    }
}