namespace UserRegistration.Controllers.Responses
{
    public class CustomResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public CustomResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}