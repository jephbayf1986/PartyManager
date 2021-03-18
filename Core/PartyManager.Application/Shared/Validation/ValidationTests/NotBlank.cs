namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal class NotBlank : ValidationTest<string>
    {
        public override string RuleDescription => $"The value provided for {FieldName} cannot be blank";

        public NotBlank(string fieldName, string value, bool continueOnError = true)
            : base(fieldName, value, continueOnError)
        {
        }

        protected override bool GetTestResult()
            => !string.IsNullOrWhiteSpace(ValueProvided);
    }
}