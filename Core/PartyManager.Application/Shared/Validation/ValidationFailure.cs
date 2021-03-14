namespace PartyManager.Application.Shared.Validation
{
    public class ValidationFailure
    {
        public string Field { get; set; }

        public string RuleBroken { get; set; }
    }
}