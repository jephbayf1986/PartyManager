using PartyManager.Application.Shared.Responding;

namespace PartyManager.Application.Shared.CQRS
{
    public interface ICommand<T> : ICommandBase<Response<T>>
    {
    }

    public interface ICommand : ICommandBase<Response>
    {
    }
}