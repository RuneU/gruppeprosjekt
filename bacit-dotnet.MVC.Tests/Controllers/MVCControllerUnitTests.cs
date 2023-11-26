using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

{
    
}
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
        Assert.IsType<HomeViewModel>(result.Model);
    }

    private static HomeController SetupUnitUnderTest()
    {
        // Substitute for ILogger
        var fakeLogger = Substitute.For<ILogger<HomeController>>();

        // Substitute for IConfiguration
        var fakeConfiguration = Substitute.For<IConfiguration>();
        
        var fakeServiceOrderRepository = Substitute.For<ServiceOrderRepository>();


        // Create an actual instance of CustomerRepository with the fakeConfiguration
        var fakeCustomerRepository = new CustomerRepository(fakeConfiguration);

        // Provide fakeCustomerRepository along with other dependencies to HomeController
        var unitUnderTest = new HomeController(fakeCustomerRepository,fakeServiceOrderRepository, fakeConfiguration );
        return unitUnderTest;
    }
}
