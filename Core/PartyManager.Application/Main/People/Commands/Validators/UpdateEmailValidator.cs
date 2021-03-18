using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.People.Commands.Validators
{
    public class UpdateEmailValidator : IValidator<UpdateEmail>
    {
        public ValidationResult Validate(UpdateEmail command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Update Email Address Request", command, false))

                            .WithValidationTest(new NotZero("Person Id", command.Id))

                            .WithValidationTest(new NotBlank("Email Address", command.Email))
                            .WithValidationTest(new TextMaxLength("Email Address", command.Email, 254))
                            .Build();
        }
    }
}