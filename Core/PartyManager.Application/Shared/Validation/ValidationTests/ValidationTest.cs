namespace PartyManager.Application.Shared.Validation.ValidationTests
{
    internal abstract class ValidationTest<T>
    {
        public abstract string FriendlyDescription { get; }

        public bool TestPass { get { return GetTestResult(); } }

        public readonly string FieldName;
        public readonly bool ContinueOnError;

        protected T ValueProvided;

        public ValidationTest(string fieldName, T value, bool continueOnError = true)
        {
            FieldName = fieldName;
            ValueProvided = value;
            ContinueOnError = continueOnError;
        }

        protected abstract bool GetTestResult();
    }
}