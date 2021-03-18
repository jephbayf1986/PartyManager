using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.PartyGuests.Commands.Validators
{
    public class RemoveGuestValidator : IValidator<RemoveGuest>
    {
        public ValidationResult Validate(RemoveGuest command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Remove Guest Request", command, true))

                            .WithValidationTest(new NotZero("Party Guest Id", command.Id))

                            .Build();
        }
    }
}