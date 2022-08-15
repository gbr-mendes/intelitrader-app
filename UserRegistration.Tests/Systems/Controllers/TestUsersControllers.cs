using FluentAssertions;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Tests.MockData;
using UserRegistration.Controllers;
using UserRegistration.Models;
using UserRegistration.Services.UserServices;

namespace UserRegistration.Tests.Systems.Controllers;

public class TestUsersControllers
{
    private readonly static Mock<IUserServices> _userServices = new Mock<IUserServices>();
    private readonly static Mock<ILogger<UsersController>> _logger = new Mock<ILogger<UsersController>>();

    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange

        _userServices.Setup(_ => _.GetUsers()).ReturnsAsync(UsersMockData.GetUsers());
        var sut = new UsersController(_userServices.Object, _logger.Object);

        // Act
        var result = await sut.GetUsers();

        // assert
        result.Result.GetType().Should().Be(typeof(OkObjectResult));
        (result.Result as OkObjectResult).StatusCode.Should().Be(200);
    }

    [Theory]
    [InlineData("uniq_id")]
    public async Task GetSingleUser_OnSuccess_ReturnsStatusCode200(string id)
    {
        // Arrange
        _userServices.Setup(_ => _.GetSingleUser(id)).ReturnsAsync(UsersMockData.GetSingleUser(id));
        var sut = new UsersController(_userServices.Object, _logger.Object);

        // Act
        var result = await sut.GetSingleUser(id);

        // Assert
        result.Result.GetType().Should().Be(typeof(OkObjectResult));
        (result.Result as OkObjectResult).StatusCode.Should().Be(200);
    }

    [Theory]
    [InlineData("unknown_id")]
    public async Task GetSingleUser_OnFail_ReturnsStatusCode404(string id)
    {
        // Arrange
        _userServices.Setup(_ => _.GetSingleUser(id)).ReturnsAsync(UsersMockData.GetSingleUser(id));
        var sut = new UsersController(_userServices.Object, _logger.Object);
        // Act
        var result = await sut.GetSingleUser(id);
        // Assert
        result.Result.GetType().Should().Be(typeof(NotFoundObjectResult));
        (result.Result as NotFoundObjectResult).StatusCode.Should().Be(404);
    }

    [Theory]
    [InlineData("John", "Due", 27)]
    [InlineData("Jane", null, 27)]
    public async Task AddUser_OnSuccess_Returns201(string name, string? surName, int age)
    {
        // Arrange
        User user = surName != null ? new User(name, surName, age) : new User(name, age);
        _userServices.Setup(_ => _.AddUser(user)).ReturnsAsync(UsersMockData.AddUser(user));
        var sut = new UsersController(_userServices.Object, _logger.Object);

        // Act
        var result = await sut.AddUser(user);

        // result
        result.Result.GetType().Should().Be(typeof(CreatedAtActionResult));
        (result.Result as CreatedAtActionResult).StatusCode.Should().Be(201);
    }

    [Theory]
    [InlineData(null, "Due", 33)]
    [InlineData("John", "Due", null)]
    public async Task AddUser_OnFail_Returns400(string name, string? surName, int age)
    {
        // Arrange
        User user = surName != null ? new User(name, surName, age) : new User(name, age);
        _userServices.Setup(_ => _.AddUser(user)).ReturnsAsync(UsersMockData.AddUser(user));
        var sut = new UsersController(_userServices.Object, _logger.Object);

        // Act
        var result = await sut.AddUser(user);
        // Assert
        result.Result.GetType().Should().Be(typeof(BadRequestObjectResult));
        (result.Result as BadRequestObjectResult).StatusCode.Should().Be(400);
    }
}