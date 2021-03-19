using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.Parties.Commands.Validators
{
    public class CreatePartyValidator : IValidator<CreateParty>
    {
        public ValidationResult Validate(CreateParty command)
        {
            return new ValidationResultBuilder()

                .WithValidationTest(new NotNull("Create Party Request", command, false))

                .WithValidationTest(new NotNull("Party Name", command.Name, false))
                .WithValidationTest(new TextMinLength("Party Name", command.Name, 5))
                .WithValidationTest(new TextMaxLength("Party Name", command.Name, 100))

                .WithValidationTest(new NotNull("Location", command.Location, false))
                .WithValidationTest(new NotBlank("Location", command.Location))
                .WithValidationTest(new TextMaxLength("Location", command.Location, 100))

                .Build();
        }
    }
}