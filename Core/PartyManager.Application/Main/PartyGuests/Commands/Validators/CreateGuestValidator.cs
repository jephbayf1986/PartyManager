using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.PartyGuests.Commands.Validators
{
    public class CreateGuestValidator : IValidator<CreateGuest>
    {
        public ValidationResult Validate(CreateGuest command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Create Guest Request", command, true))

                            .WithValidationTest(new NotZero("Party Id", command.PartyId))

                            .WithValidationTest(new NotZero("Person Id", command.PersonId))

                            .Build();
        }
    }
}