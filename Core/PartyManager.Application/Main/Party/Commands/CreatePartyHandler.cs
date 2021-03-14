using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.Responding;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Party.Commands
{
    public class CreatePartyHandler : ICommandHandler<CreateParty, Response<int>>
    {
        public Task<Response<int>> Handle(CreateParty command, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
