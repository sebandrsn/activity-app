namespace ActivityApp.Application.Common.Responses
{
    public class Response
    {
        public bool Success { get; set; }
        public List<string>? ValidationErrors { get; set; }
    }
}
