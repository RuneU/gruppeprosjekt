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
            // Create mock objects for dependencies
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
            // Create the controller with the mock dependencies
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
            // Attempt to log in with null model
            var result = controller.Login(null);

            // ASSERT
            // Verify that the result is a ViewResult with null ViewName
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);

            // Verify that all expected methods on mock objects were called
            userManagerMock.VerifyAll();
            signInManagerMock.VerifyAll();
            emailSenderMock.VerifyAll();
            userRepositoryMock.VerifyAll();
        }

    }

}