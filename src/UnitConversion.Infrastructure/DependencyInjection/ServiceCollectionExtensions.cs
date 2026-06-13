using Microsoft.Extensions.DependencyInjection;
using UnitConversion.Application.Interfaces;
using UnitConversion.Infrastructure.Converters;

namespace UnitConversion.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection
        AddInfrastructure(
            this IServiceCollection services)
    {
        services.AddScoped<
            IUnitConverter,
            LengthConverter>();

        services.AddScoped<
            IUnitConverter,
            WeightConverter>();

        services.AddScoped<
            IUnitConverter,
            TemperatureConverter>();

        return services;
    }
}