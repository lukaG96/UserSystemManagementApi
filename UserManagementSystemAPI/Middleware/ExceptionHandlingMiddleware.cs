using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using UserManagementSystemAPI.Shared.Exceptions;

namespace UserManagementSystemAPI.Middleware
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
               // _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = exception switch
            {

                NotAuthorizedException or SecurityTokenException => StatusCodes.Status401Unauthorized,
                OperationFailedException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new
            {
                message = exception.Message
            };


            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
