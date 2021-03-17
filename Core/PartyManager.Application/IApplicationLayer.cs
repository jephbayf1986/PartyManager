using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application
{
    public interface IApplicationLayer
    {
        Task<T> Execute<T>(ICommandBase<T> command);

        Task<T> Acquire<T>(IQuery<T> query);
    }
}