using PartyManager.Application.Shared.Validation;
using System;

namespace PartyManager.Application.Shared.Exceptions
{
    internal class ValidationException : Exception
    {
        public readonly ValidationResult ValidationResult;

        public ValidationException(ValidationResult result)
            : base($"The Request contained {result.NumberOfFailures} validation errors")
        {
            ValidationResult = result;
        }
    }
}