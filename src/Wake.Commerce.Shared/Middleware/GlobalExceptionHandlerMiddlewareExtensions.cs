using Microsoft.AspNetCore.Builder;

namespace Wake.Commerce.Shared.Middleware
{
    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
