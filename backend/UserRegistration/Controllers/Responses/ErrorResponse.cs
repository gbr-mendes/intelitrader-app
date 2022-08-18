namespace UserRegistration.Controllers.Responses
{
    public class ErrorResponse : CustomResponse
    {
        public List<string> Errors { get; set; }
        public ErrorResponse(int statusCode, string message, List<string> errors) : base(statusCode, message)
        {
            Errors = errors;
        }
    }
}