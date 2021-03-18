namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal class NumericMinimum : ValidationTest<decimal>
    {
        public override string FriendlyDescription => $"The Value provided for {FieldName} can be no less than {MinValue}";

        private decimal MinValue;

        public NumericMinimum(string fieldName, decimal value, decimal minValue, bool continueOnError = true)
            : base(fieldName, value, continueOnError)
        {
            MinValue = minValue;
        }

        protected override bool GetTestResult()
            => ValueProvided >= MinValue;
    }
}