using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.People.Commands
{
    public class CreatePersonHandler : PersonBase, ICommandHandler<CreatePerson, Response<int>>
    {
        private readonly IPersonDataProvider _dataProvider;

        public CreatePersonHandler(IPersonDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response<int>> Handle(CreatePerson command)
        {
            var request = new InsertPersonRequest
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
                Email = command.Email,
                Phone = command.Phone,
                FavouriteDrinkId = command.FavouriteDrinkId
            };

            var newPartyId = await _dataProvider.InsertPerson(request);

            return SuccessHandler.ReturnInsertSuccess(newPartyId, EntityName);
        }
    }
}