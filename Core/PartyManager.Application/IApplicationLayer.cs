using PartyManager.Application.Shared.CQRS;
using System.Threading;
using System.Threading.Tasks;

namespace PartyManager.Application
{
    public interface IApplicationLayer
    {
        Task<T> Send<T>(ICommandBase<T> command, CancellationToken token = default);

        Task<T> Send<T>(IQuery<T> request, CancellationToken token = default);
    }
}