using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.Parties.Commands.Validators
{
    public class UpdatePartyStartTimeValidator : IValidator<UpdatePartyStartTime>
    {
        public ValidationResult Validate(UpdatePartyStartTime command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Update Party Request", command, false))

                            .WithValidationTest(new NotZero("Party Id", command.Id))

                            .Build();
        }
    }
}