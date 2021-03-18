using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.People.Commands.Validators
{
    public class UpdateFavouriteDrinkValidator : IValidator<UpdateFavouriteDrink>
    {
        public ValidationResult Validate(UpdateFavouriteDrink command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Update Favourite Drink Request", command, false))

                            .WithValidationTest(new NotZero("Person Id", command.Id))

                            .WithValidationTest(new NotZero("Favourite Drink Id", command.FavouriteDrinkId))

                            .Build();
        }
    }
}