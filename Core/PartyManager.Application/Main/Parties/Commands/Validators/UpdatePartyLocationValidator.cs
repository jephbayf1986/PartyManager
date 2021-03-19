using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.Parties.Commands.Validators
{
    public class UpdatePartyLocationValidator : IValidator<UpdateLocation>
    {
        public ValidationResult Validate(UpdateLocation command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Update Location Request", command, false))

                            .WithValidationTest(new NotZero("Party Id", command.Id))

                            .WithValidationTest(new NotNull("Location", command.Location, false))
                            .WithValidationTest(new NotBlank("Location", command.Location))
                            .WithValidationTest(new TextMaxLength("Location", command.Location, 100))

                            .Build();
        }
    }
}