using FluentAssertions;
using UserRegistration.Services.UserServices;
using UserRegistration.Controllers;
using Microsoft.Extensions.Logging;
using UserRegistration.Dtos.User;
using UserRegistration.Tests.MockData;
using System.ComponentModel.DataAnnotations;
using Moq;

namespace UserRegistration.Tests.Systems.Models
{
    public class UserDtosValidation
    {
        private readonly static Mock<IUserServices> _userServices = new Mock<IUserServices>();
        private readonly static Mock<ILogger<UsersController>> _logger = new Mock<ILogger<UsersController>>();

        [Theory]
        [InlineData("John", "Doe", 33)]
        [InlineData("Jane", null, 33)]
        public void AddUpdateUserDto_IsValid_ReturnsTrue(string name, string surName, int age)
        {
            // Arrange
            var sut = new AddUpdateUserDto { Name = name, SurName = surName, Age = age };
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            // Act
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);
            // Assert
            isModelStateValid.Should().Be(true);
        }

        [Theory]
        [InlineData(null, "Doe", 33)]
        [InlineData("Jane", "Doe", 0)]
        [InlineData(null, "Doe", -1)]
        public void AddUpdateUserDto_IsInvalid_ReturnsFalse(string name, string surName, int age)
        {
            // Arrange
            var sut = new AddUpdateUserDto { Name = name, SurName = surName, Age = age };
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            // Act
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);
            // Assert
            isModelStateValid.Should().Be(false);
        }
    }
}