using Store.G04.APIs.Errors;
using System.Net;
using System.Text.Json;

namespace Store.G04.APIs.Middlewares
{
	public class ExceptionMiddleWare
	{
		private readonly ILogger<ExceptionMiddleWare> _logger;
		private readonly IHostEnvironment _environment;
		private readonly RequestDelegate _next;

		public ExceptionMiddleWare(ILogger<ExceptionMiddleWare> logger , IHostEnvironment environment , RequestDelegate next)
        {
			_logger = logger;
			_environment = environment;
			_next = next;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{			
				await _next.Invoke(context);

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message); //Log exception in DB
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

				var Response = _environment.IsDevelopment() ? new ApiExceptionHandler((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace) : new ApiExceptionHandler((int)HttpStatusCode.InternalServerError);

			}
		}
    }
}
