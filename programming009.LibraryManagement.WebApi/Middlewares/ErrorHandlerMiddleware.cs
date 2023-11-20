using Newtonsoft.Json;

using programming009.LibraryManagement.WebApi.Models;

using System.Net;
using System.Text.Json.Serialization;

namespace programming009.LibraryManagement.WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate request, ILogger<ErrorHandlerMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (ApiException e)
            {
                _logger.LogCritical(e, "api exception occured");
                //return bad request
                await this.HandleErrorAsync(context, HttpStatusCode.BadRequest, e.Message);
            }
            catch (NotFoundException e)
            {
                _logger.LogCritical(e, "api exception occured");
                //return 404 not found
                await this.HandleErrorAsync(context, HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "api exception occured");
                //return 500 internal server error
                await this.HandleErrorAsync(context, HttpStatusCode.InternalServerError, "Something went wrong... Please try again");
            }
        }

        private async Task HandleErrorAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)statusCode;

            ErrorResponseModel model = new ErrorResponseModel
            {
                Message = message
            };

            await response.WriteAsJsonAsync(model, typeof(ErrorResponseModel));
        }
    }
}
