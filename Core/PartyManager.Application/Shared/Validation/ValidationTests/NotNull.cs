namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal class NotNull : ValidationTest<object>
    {
        public override string FriendlyDescription => $"No value was be provided for {FieldName}";

        public NotNull(string fieldName, object value, bool continueOnError = true)
            : base(fieldName, value, continueOnError)
        {
        }

        protected override bool GetTestResult()
            => ValueProvided != null;
    }
}