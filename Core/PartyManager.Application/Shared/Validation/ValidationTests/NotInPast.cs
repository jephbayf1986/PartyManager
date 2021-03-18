using System;

namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal class NotInPast : ValidationTest<DateTime>
    {
        public override string FriendlyDescription => $"The value provided for {FieldName} cannot be in the past";

        public NotInPast(string fieldName, DateTime value, bool continueOnError = true)
            : base(fieldName, value, continueOnError)
        {
        }

        protected override bool GetTestResult()
            => ValueProvided >= DateTime.Now;
    }
}