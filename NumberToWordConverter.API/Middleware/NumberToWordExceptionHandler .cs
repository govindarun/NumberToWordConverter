using Microsoft.AspNetCore.Diagnostics;

namespace NumberToWordConverter.API.Middleware
{
	public class NumberToWordExceptionHandler(ILogger<NumberToWordExceptionHandler> logger) : IExceptionHandler
	{
		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
		{
			logger.LogError(exception, "An error occurred while processing the request.");

			var errorResponse = new ErrorResponse
			{
				Title = "An error occurred",
				Message = exception.Message
			};

			await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken: cancellationToken);

			return true;
		}
	}

	public class ErrorResponse
	{
		public required string Title { get; set; }
		
		public required string Message { get; set; }
	}
}
