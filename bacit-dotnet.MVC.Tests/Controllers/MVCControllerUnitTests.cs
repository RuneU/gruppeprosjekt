using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models;
using bacit_dotnet.MVC.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bacit_dotnet.MVC.Tests.Controllers
{
#pragma warning disable CS8602 //Disable null reference warnings, if something is null the test should fail. 

    public class MVCControllerUnitTests
    {

        [Fact]
        public void IndexReturnsCorrectContent() 
        {
            var unitUnderTest = SetupUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void UsingRazorReturnsCorrectModel()
        {
            var unitUnderTest = SetupUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.IsType<HomeIndexViewModel>(result.Model);
        }

        

        private static HomeController SetupUnitUnderTest()
        {
            var fakeLogger = Substitute.For<ILogger<HomeController>>(); //Set up a fake for dependency (this works with all interfaces)
            var unitUnderTest = new HomeController(fakeLogger); //Create the class we want to test
            return unitUnderTest;
        }
    }
}
