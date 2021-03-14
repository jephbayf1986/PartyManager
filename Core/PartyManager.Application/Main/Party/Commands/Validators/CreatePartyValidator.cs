using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.Party.Commands.Validators
{
    public class CreatePartyValidator : IValidator<CreateParty>
    {
        public ValidationResult Validate(CreateParty command)
        {
            var resultBuilder = new ValidationResultBuilder()

                .WithValidationTest(new NotNull("Create Party Request", command, false))

                .WithValidationTest(new NotBlank("Party Name", command.Name));

            return resultBuilder.Build();
        }
    }
}