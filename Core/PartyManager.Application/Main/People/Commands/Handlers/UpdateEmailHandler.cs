using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.People.Commands
{
    public class UpdateEmailHandler : PersonBase, ICommandHandler<UpdateEmail, Response>
    {
        private readonly IPersonDataProvider _dataProvider;

        public UpdateEmailHandler(IPersonDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdateEmail command)
        {
            var request = new UpdatePersonRequest()
            {
                Id = command.Id,
                Email = command.Email
            };

            await _dataProvider.UpdatePerson(request);

            return SuccessHandler.ReturnUpdateSuccess(EntityName);
        }
    }
}