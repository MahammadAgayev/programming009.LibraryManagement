using Newtonsoft.Json;

using programming009.LibraryManagement.WebApi.Models;

using System.Net;
using System.Text.Json.Serialization;

namespace programming009.LibraryManagement.WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _request;

        public ErrorHandlerMiddleware(RequestDelegate request)
        {
            _request = request; 
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (ApiException e)
            {
                //return bad request
                await this.HandleErrorAsync(context, HttpStatusCode.BadRequest, e.Message);
            }
            catch (NotFoundException e)
            {
                //return 404 not found
                await this.HandleErrorAsync(context, HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                //return 500 internal server error
                await this.HandleErrorAsync(context, HttpStatusCode.InternalServerError, e.Message);
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
