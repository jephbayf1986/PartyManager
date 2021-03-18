using System;

namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal class NotZero : ValidationTest<decimal>
    {
        public override string RuleDescription => throw new NotImplementedException();

        public NotZero(string fieldName, decimal value, bool continueOnError = true)
            : base(fieldName, value, continueOnError)
        {
        }

        protected override bool GetTestResult()
            => ValueProvided != 0;
    }
}
