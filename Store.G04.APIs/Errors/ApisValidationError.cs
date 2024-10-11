namespace Store.G04.APIs.Errors
{
	public class ApisValidationError:APIsResponseError
	{
        public IEnumerable<string> Errors { get; set; } 
        public ApisValidationError():base(400)
        {
            Errors = new List<string>();
        }
    }
}
