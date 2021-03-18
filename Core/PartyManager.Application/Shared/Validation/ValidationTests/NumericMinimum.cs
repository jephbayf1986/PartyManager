namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal class NumericMinimum : ValidationTest<decimal>
    {
        public override string RuleDescription => $"The Value provided for {FieldName} can be no more than {MinValue}";

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