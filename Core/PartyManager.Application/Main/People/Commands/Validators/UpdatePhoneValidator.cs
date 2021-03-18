using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.People.Commands.Validators
{
    public class UpdatePhoneValidator : IValidator<UpdatePhone>
    {
        public ValidationResult Validate(UpdatePhone command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Update Phone Number Request", command, false))

                            .WithValidationTest(new NotZero("Person Id", command.Id))

                            .WithValidationTest(new NotBlank("Phone Number", command.Phone))
                            .WithValidationTest(new TextMaxLength("Phone Number", command.Phone, 20))
                            .Build();
        }
    }
}