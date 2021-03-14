using PartyManager.Application.Shared.CQRS;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PartyManager.Application.Main
{
    public class ApplicationLayer : IApplicationLayer
    {
        public Task<T> Send<T>(ICommandBase<T> command, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> Send<T>(IQuery<T> request, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}