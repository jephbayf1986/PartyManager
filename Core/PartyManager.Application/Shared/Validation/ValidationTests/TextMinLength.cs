namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal class TextMinLength : ValidationTest<string>
    {
        public override string FriendlyDescription => $"The value provided for {FieldName} must be no less than {MinLength} characters";

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