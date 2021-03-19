using Moq;
using PartyManager.Application.Main.Drinks.Commands;
using PartyManager.Application.Main.Drinks.Commands.Handlers;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Testing.TestHelpers;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace PartyManager.Testing.Core.Application.Main.Drinks
{
    public class CreateDrinkCommandUnitTest
    {
        [Fact]
        public async Task ExecuteCreateDrink_PassRequestToProvider_ReturnResultWrappedInResponse()
        {
            // Arrange
            var request = new CreateDrink()
            {
                Name = "Carrot Juice"
            };

            var expectedId = RandomHelper.NumberBetween(10, 20);

            var dataProvider = new Mock<IDrinkDataProvider>();

            dataProvider.Setup(x => x.InsertDrink(request.Name))
                .ReturnsAsync(expectedId);

            var handler = new CreateDrinkHandler(dataProvider.Object);

            // Act
            var result = await handler.Handle(request);

            // Assert
            result.ShouldNotBeNull();
            result.Payload.ShouldBe(expectedId);
        }
    }
}