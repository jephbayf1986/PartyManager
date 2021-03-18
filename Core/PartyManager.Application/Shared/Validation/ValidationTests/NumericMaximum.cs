namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal class NumericMaximum : ValidationTest<decimal>
    {
        public override string FriendlyDescription => $"The Value provided for {FieldName} can be no more than {MaxValue}";

        private decimal MaxValue;

        public NumericMaximum(string fieldName, decimal value, decimal maxValue, bool continueOnError = true)
            : base(fieldName, value, continueOnError)
        {
            MaxValue = maxValue;
        }

        protected override bool GetTestResult()
            => ValueProvided <= MaxValue;
    }
}
