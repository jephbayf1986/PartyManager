using System;

namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal class TextMinLength : ValidationTest<string>
    {
        public override string RuleDescription => throw new NotImplementedException();

        private readonly int MinLength;

        public TextMinLength(string fieldName, string value, int minLength, bool continueOnError = true)
            : base(fieldName, value, continueOnError)
        {
            MinLength = minLength;
        }

        protected override bool GetTestResult()
            => ValueProvided.Length >= MinLength;
    }
}