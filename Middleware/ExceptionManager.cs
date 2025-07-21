using System.Net;

public class ExceptionHandlingMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<ExceptionHandlingMiddleware> _logger;

  public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task Invoke(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (AppException ex)
    {
      // _logger.LogError(ex, "Unhandled Exception");

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = ex.StatusCode;

      var response = new { error = ex.Message };
      await context.Response.WriteAsJsonAsync(response);
    }
  }
}

public class AppException : Exception
{
  public int StatusCode { get; }

  public AppException(string message, int statusCode = 400) : base(message)
  {
    StatusCode = statusCode;
  }
}