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
				Message = exception.Message,
				StatusCode = StatusCodes.Status400BadRequest
			};

			await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken: cancellationToken);
			httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

			return true;
		}
	}

	public class ErrorResponse
	{
		public string Title { get; set; }
		public string Message { get; set; }
		public int StatusCode { get; set; }
	}
}
