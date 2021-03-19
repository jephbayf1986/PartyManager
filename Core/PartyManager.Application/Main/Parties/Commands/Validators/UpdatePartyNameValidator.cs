using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.Parties.Commands.Validators
{
    public class UpdatePartyNameValidator : IValidator<UpdatePartyName>
    {
        public ValidationResult Validate(UpdatePartyName command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Update Party Name Request", command, false))

                            .WithValidationTest(new NotZero("Party Id", command.Id))

                            .WithValidationTest(new NotNull("Party Name", command.Name, false))
                            .WithValidationTest(new TextMinLength("Party Name", command.Name, 5))
                            .WithValidationTest(new TextMaxLength("Party Name", command.Name, 100))

                            .Build();
        }
    }
}