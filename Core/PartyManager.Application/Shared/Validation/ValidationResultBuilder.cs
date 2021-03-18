using PartyManager.Application.Shared.Exceptions;
using PartyManager.Application.Shared.Validation.ValidationTests;

namespace PartyManager.Application.Shared.Validation
{
    internal class ValidationResultBuilder
    {
        private ValidationResult result;

        public ValidationResultBuilder()
        {
            result = new ValidationResult();
        }

        public ValidationResultBuilder WithValidationTest<T>(ValidationTest<T> validationTest)
        {
            if (!validationTest.TestPass)
            {
                result.AddFailure(validationTest.FieldName, validationTest.FriendlyDescription);

                if (!validationTest.ContinueOnError)
                {
                    throw new ValidationException(result);
                }
            }

            return this;
        }

        public ValidationResult Build()
        {
            return result;
        }
    }
}