namespace SkinetWebApi.Errors
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request.",
                401 => "You are not authorised.",
                404 => "Resource not found.",
                500 => "internal server error.",
                _ => null
            };
        }
    }
}
