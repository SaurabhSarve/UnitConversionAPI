using UnitConversion.API.Middleware;

namespace UnitConversion.API.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder
        UseGlobalExceptionHandling(
            this IApplicationBuilder app)
    {
        app.UseMiddleware<
            ExceptionMiddleware>();

        return app;
    }
}