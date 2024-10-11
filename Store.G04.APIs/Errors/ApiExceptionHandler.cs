namespace Store.G04.APIs.Errors
{
	public class ApiExceptionHandler :APIsResponseError
	{
        public string ?Details { get; set; }
        public ApiExceptionHandler(int statuscode , string? ErrorMessage = null , string?details = null):base(statuscode , ErrorMessage)
        {
            statuscode = StatusCode;
            ErrorMessage = Message;
            details = Details;
        }

    }
}
