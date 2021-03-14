using PartyManager.Application.Shared.Validation;

namespace PartyManager.Application.Shared.CQRS
{
    public interface ICommandBase<out T> : ICanValidate
    {
    }
}