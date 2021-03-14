namespace PartyManager.Application.Shared.Validation
{
    public interface IValidator<TCommand>
        where TCommand : ICanValidate
    {
        ValidationResult Validate(TCommand command);
    }
}