using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.Parties.Commands.Validators
{
    public class UpdatePartyStartTimeValidator : IValidator<UpdateStartTime>
    {
        public ValidationResult Validate(UpdateStartTime command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Update Start Time Request", command, false))

                            .WithValidationTest(new NotZero("Party Id", command.Id))

                            .Build();
        }
    }
}