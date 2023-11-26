using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models.Sjekkliste;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;


namespace bacit_dotnet.MVC.Tests.Controllers
{
    public class SjekklisteControllerTests
    {
        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Arrange
            var configuration = new ConfigurationBuilder()
                // Add any configuration settings needed for your test
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "1", "1" }
                })
                .Build();

            var checkListRepository = new CheckListRepository(configuration);
            var controller = new SjekklisteController(checkListRepository);

            // Act
            var result = controller.Create(1);

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}