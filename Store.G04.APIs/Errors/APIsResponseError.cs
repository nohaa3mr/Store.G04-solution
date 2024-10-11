
namespace Store.G04.APIs.Errors
{
	public class APIsResponseError
	{
        public int StatusCode { get; set; }

        public string ?Message { get; set; }
        public APIsResponseError(int statuscode , string? errormessage= null)
        {
            StatusCode = statuscode;
            Message = errormessage ?? GetDefaultMessageForStatusCode(StatusCode);

        }

		private string? GetDefaultMessageForStatusCode(int statusCode)
		{
            return statusCode switch 
            {
                400 => "Error Not Found",
                401 => "UnAuthorized",
                404 => "Resource Not Found",
                500 => "Internal Server Error",
                _ => null
            };

		}
	}
}
