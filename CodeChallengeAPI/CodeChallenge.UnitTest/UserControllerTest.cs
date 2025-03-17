using CodeChallengeAPI.Controllers;
using CodeChallengeAPI.Models;
using CodeChallengeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CodeChallengeAPI.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<IAuthenticationRepository> _authRepoMock;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _authRepoMock = new Mock<IAuthenticationRepository>();
            _controller = new UserController(_authRepoMock.Object);
        }

        [Fact]
        public void GetLoginDetails_ValidUser_ReturnsOkResult()
        {
            // Arrange
            var userDetails = new UserDetails
            {
                UserName = "Developer123",
                Usertype = "Admin",
                AccessToken = "valid_token"
            };
            _authRepoMock.Setup(repo => repo.AuthenticateUser("Developer123", "password"))
                         .Returns(userDetails);

            // Act
            var result = _controller.GetLoginDetails("Developer123", "password");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<UserDetails>(okResult.Value);
            Assert.Equal("Developer123", returnValue.UserName);
            Assert.Equal("valid_token", returnValue.AccessToken);
        }

        [Fact]
        public void GetLoginDetails_InvalidUser_ReturnsBadRequest()
        {
            // Arrange
            _authRepoMock.Setup(repo => repo.AuthenticateUser("InvalidUser", "password"))
                         .Returns(new UserDetails());

            // Act
            var result = _controller.GetLoginDetails("InvalidUser", "password");

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid User", badRequestResult.Value);
        }

        [Fact]
        public void GetLoginDetails_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("userName", "Required");

            // Act
            var result = _controller.GetLoginDetails("", "password");

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var serializableError = Assert.IsType<SerializableError>(badRequestResult.Value);
            Assert.Equal(new SerializableError(_controller.ModelState), serializableError);

        }
    }
}
