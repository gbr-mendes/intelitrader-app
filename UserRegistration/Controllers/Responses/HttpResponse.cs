namespace UserRegistration.Controllers.Responses
{
    public class HttpResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public HttpResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}