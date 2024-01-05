using Microsoft.AspNetCore.Http;
using System.Net;
using FluentValidation;
using Wake.Commerce.Shared.DTO;
using Wake.Commerce.Shared.Extensions;

namespace Wake.Commerce.Shared.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        public GlobalExceptionHandlerMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            IEnumerable<string> mensagensErro;

            switch (exception)
            {
                case ValidationException ex:
                    mensagensErro = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage).AsEnumerable();
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    context.Response.StatusCode = (int)statusCode;

                    mensagensErro = new List<string> { exception.InnerException?.Message ?? exception.Message };
                    break;
            }

            return context.Response.WriteAsync(new BaseResponseDto<object>(false, (int)statusCode, mensagensErro).ToJsonIgnoringNullValues());
        }
    }
}
