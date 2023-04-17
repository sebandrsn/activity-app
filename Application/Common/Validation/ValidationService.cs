namespace ActivityApp.Application.Common.Validation
{
    public class ValidationService : IValidationService
    {
        public ValidationService()
        {
            
        }

        public bool AllCharIsLetter(string input)
        {
            return input.All(char.IsLetter);
        }
    }
}
