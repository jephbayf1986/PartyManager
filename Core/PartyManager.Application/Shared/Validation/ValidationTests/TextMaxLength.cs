using System;

namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal class TextMaxLength : ValidationTest<string>
    {
        public override string RuleDescription => throw new NotImplementedException();

        private readonly int MaxLength;

        public TextMaxLength(string fieldName, string value, int maxLength, bool continueOnError = true)
            : base(fieldName, value, continueOnError)
        {
            MaxLength = maxLength;
        }

        protected override bool GetTestResult()
            => ValueProvided.Length <= MaxLength;
    }
}
