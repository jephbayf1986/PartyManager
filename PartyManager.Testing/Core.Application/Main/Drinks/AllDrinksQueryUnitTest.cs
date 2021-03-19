using Moq;
using PartyManager.Application.Main.Drinks.Queries;
using PartyManager.Application.Main.Drinks.Queries.Handlers;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Domain;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PartyManager.Testing.Core.Application.Main.Drinks
{
    public class AllDrinksQueryUnitTest
    {
        [Fact]
        public async Task GetAllDrinks_PassRequestToProvider_MapFields()
        {
            // Arrange
            var expectedResult = new List<Drink>()
            {
                new Drink { Id = 1, Name = "Water" },
                new Drink { Id = 2, Name = "Vodka" }
            };

            var dataProvider = new Mock<IDrinkDataProvider>();

            dataProvider.Setup(x => x.GetDrinks())
                .ReturnsAsync(expectedResult);
            
            var request = new AllDrinks();

            var handler = new AllDrinksHandler(dataProvider.Object);

            // Act
            var result = await handler.Handle(request);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(expectedResult.Count);
            result.First().Id.ShouldBe(expectedResult.First().Id);
        }
    }
}