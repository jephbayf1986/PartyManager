using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.PartyGuests.Commands.Validators
{
    public class UpdateChosenDrinkValidator : IValidator<UpdateChosenDrink>
    {
        public ValidationResult Validate(UpdateChosenDrink command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Update Drink Choice Request", command, true))

                            .WithValidationTest(new NotZero("Party Guest Id", command.Id))

                            .Build();
        }
    }
}