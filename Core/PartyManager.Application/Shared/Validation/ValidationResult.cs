using System.Collections.Generic;

namespace PartyManager.Application.Shared.Validation
{
    public class ValidationResult
    {
        public bool HasFailures { get { return NumberOfFailures > 0; } }

        public int NumberOfFailures { get { return Failures.Count; } }

        public List<ValidationFailure> Failures { get; private set; }

        public ValidationResult()
        {
            Failures = new List<ValidationFailure>();
        }

        public void AddFailure(string field, string ruleBroken)
        {
            Failures.Add(new ValidationFailure { Field = field, RuleBroken = ruleBroken });
        }

        public void CombineWith(ValidationResult otherResult)
        {
            foreach (var failure in otherResult.Failures)
            {
                Failures.Add(failure);
            }
        }
    }
}