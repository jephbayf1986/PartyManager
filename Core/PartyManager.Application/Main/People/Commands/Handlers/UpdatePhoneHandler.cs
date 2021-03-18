using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.People.Commands
{
    public class UpdatePhoneHandler : PersonBase, ICommandHandler<UpdatePhone, Response>
    {
        private readonly IPersonDataProvider _dataProvider;

        public UpdatePhoneHandler(IPersonDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdatePhone command)
        {
            var request = new UpdatePersonRequest()
            {
                Id = command.Id,
                Phone = command.Phone
            };

            await _dataProvider.UpdatePerson(request);

            return SuccessHandler.ReturnUpdateSuccess(EntityName);
        }
    }
}