using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.Drinks.Commands.Validators
{
    public class InsertDrinkValidator : IValidator<CreateDrink>
    {
        public ValidationResult Validate(CreateDrink command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Insert Drink Request", command, false))

                            .WithValidationTest(new NotNull("Drink Name", command.Name, false))
                            .WithValidationTest(new TextMinLength("Drink Name", command.Name, 3))
                            .WithValidationTest(new TextMaxLength("Drink Name", command.Name, 100))

                            .Build();
        }
    }
}