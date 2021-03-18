using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.People.Commands.Validators
{
    public class CreatePersonValidator : IValidator<CreatePerson>
    {
        public ValidationResult Validate(CreatePerson command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Create Person Request", command, false))

                            .WithValidationTest(new NotNull("First Name", command.FirstName, false))
                            .WithValidationTest(new TextMinLength("First Name", command.FirstName, 3))
                            .WithValidationTest(new TextMaxLength("First Name", command.FirstName, 50))

                            .WithValidationTest(new NotNull("Last Name", command.LastName, false))
                            .WithValidationTest(new TextMinLength("Last Name", command.LastName, 3))
                            .WithValidationTest(new TextMaxLength("Last Name", command.LastName, 50))

                            .WithValidationTest(new NotBlank("Email Address", command.Email))
                            .WithValidationTest(new TextMaxLength("Email Address", command.Email, 254))

                            .WithValidationTest(new NotBlank("Phone Number", command.Phone))
                            .WithValidationTest(new TextMaxLength("Phone Number", command.Phone, 20))
                            .Build();
        }
    }
}