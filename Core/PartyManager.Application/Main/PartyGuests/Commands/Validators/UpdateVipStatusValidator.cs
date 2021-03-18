using PartyManager.Application.Shared.Validation;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Main.PartyGuests.Commands.Validators
{
    public class UpdateVipStatusValidator : IValidator<UpdateVipStatus>
    {
        public ValidationResult Validate(UpdateVipStatus command)
        {
            return new ValidationResultBuilder()
                            .WithValidationTest(new NotNull("Update VIP Status Request", command, true))

                            .WithValidationTest(new NotZero("Party Guest Id", command.Id))

                            .Build();
        }
    }
}