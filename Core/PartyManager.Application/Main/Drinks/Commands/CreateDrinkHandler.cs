using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Drinks.Commands
{
    public class CreateDrinkHandler : DrinkBase, ICommandHandler<CreateDrink, Response<int>>
    {
        private readonly IDrinkDataProvider _dataProvider;

        public CreateDrinkHandler(IDrinkDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response<int>> Handle(CreateDrink command)
        {
            var newDrinkId = await _dataProvider.InsertDrink(command.Name);

            return SuccessHandler.ReturnInsertSuccess(newDrinkId, EntityName);
        }
    }
}