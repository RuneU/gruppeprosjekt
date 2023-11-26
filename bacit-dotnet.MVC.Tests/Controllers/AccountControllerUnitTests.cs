using System.Collections.Generic;
using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models.Account;
using bacit_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace bacit_dotnet.MVC.Tests.Controllers
{
    public class AccountControllerTests
    {
        [Fact]
        public void Login_ReturnsViewForInvalidModel()
        {
            // ARRANGE
            // Mock UserManager with necessary dependencies
            var userManagerMock = new Mock<UserManager<IdentityUser>>(
                Mock.Of<IUserStore<IdentityUser>>(),
                Mock.Of<IOptions<IdentityOptions>>(),
                Mock.Of<IPasswordHasher<IdentityUser>>(),
                new List<IUserValidator<IdentityUser>>(),
                new List<IPasswordValidator<IdentityUser>>(),
                Mock.Of<ILookupNormalizer>(),
                Mock.Of<IdentityErrorDescriber>(),
                Mock.Of<IServiceProvider>(),
                Mock.Of<ILogger<UserManager<IdentityUser>>>()
            );
            // Mock SignInManager with necessary dependencies, including userManagerMock
            var signInManagerMock = new Mock<SignInManager<IdentityUser>>(
                userManagerMock.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<IdentityUser>>(),
                null, null, null, null
            );
            // Mock IEmailSender for simulating email sending
            var emailSenderMock = new Mock<IEmailSender>();

            // Create a LoggerFactory with a console logger
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            // Mock IUserRepository for simulating user repository behavior
            var userRepositoryMock = new Mock<IUserRepository>();

            // Create an instance of AccountController with the mocked dependencies
            var controller = new AccountController(userManagerMock.Object, signInManagerMock.Object,
                emailSenderMock.Object, loggerFactory, userRepositoryMock.Object);

            // ACT
            // Invoke the Login action with null model
            var result = controller.Login(null);

            // ASSERT
            // Verify that the result is of type ViewResult and the ViewName is null
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);

            // Verify that the expected methods on mocked objects are called
            userManagerMock.VerifyAll();
            signInManagerMock.VerifyAll();
            emailSenderMock.VerifyAll();
            userRepositoryMock.VerifyAll();
        }

    }

}