using System.Threading.Tasks;

namespace PartyManager.Application.Shared.CQRS
{
    public interface ICommandHandler<in TCommand, TReturn>
        where TCommand : ICommandBase<TReturn>
    {
        Task<TReturn> Handle(TCommand command);
    }
}