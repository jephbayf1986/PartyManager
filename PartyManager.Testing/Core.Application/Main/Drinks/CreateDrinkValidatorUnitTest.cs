using PartyManager.Application.Main.Drinks.Commands;
using PartyManager.Application.Main.Drinks.Commands.Validators;
using PartyManager.Application.Shared.Exceptions;
using PartyManager.Testing.TestHelpers;
using Shouldly;
using Xunit;

namespace PartyManager.Testing.Core.Application.Main.Drinks
{
    public class CreateDrinkValidatorUnitTest
    {
        [Fact]
        public void CreateDrinkRequest_NameFilled_ShouldPass()
        {
            // Arrange
            var request = new CreateDrink()
            {
                Name = "Wisky"
            };

            var validator = new CreateDrinkValidator();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.HasFailures.ShouldBeFalse();
        }

        [Fact]
        public void CreateDrinkRequest_NullRequest_ShouldThrowException()
        {
            // Arrange
            CreateDrink request = null;

            var validator = new CreateDrinkValidator();

            // Act
            var exception = Should.Throw<ValidationException>(() => validator.Validate(request));

            // Arrange
            exception.Message.ShouldNotBeNullOrWhiteSpace();
            exception.ValidationResult.HasFailures.ShouldBeTrue();
        }

        [Fact]
        public void CreateDrinkRequest_NullName_ShouldFail()
        {
            // Arrange
            var request = new CreateDrink()
            {
                Name = null
            };

            var validator = new CreateDrinkValidator();

            // Act
            var exception = Should.Throw<ValidationException>(() => validator.Validate(request));

            // Arrange
            exception.Message.ShouldNotBeNullOrWhiteSpace();
            exception.ValidationResult.HasFailures.ShouldBeTrue();
        }

        [Fact]
        public void CreateDrinkRequest_ShortName_ShouldFail()
        {
            // Arrange
            var request = new CreateDrink()
            {
                Name = "A"
            };

            var validator = new CreateDrinkValidator();

            // Act
            var result = validator.Validate(request);

            // Arrange
            result.HasFailures.ShouldBeTrue();
        }

        [Fact]
        public void CreateDrinkRequest_LongName_ShouldFail()
        {
            // Arrange
            var request = new CreateDrink()
            {
                Name = RandomHelper.StringOfLength(101)
            };

            var validator = new CreateDrinkValidator();

            // Act
            var result = validator.Validate(request);

            // Arrange
            result.HasFailures.ShouldBeTrue();
        }
    }
}