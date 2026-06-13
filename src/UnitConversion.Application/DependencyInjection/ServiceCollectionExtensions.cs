using Microsoft.Extensions.DependencyInjection;
using UnitConversion.Application.Interfaces;
using UnitConversion.Application.Services;

namespace UnitConversion.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection
        AddApplication(
            this IServiceCollection services)
    {
        services.AddScoped<
            IConversionService,
            ConversionService>();

        return services;
    }
}