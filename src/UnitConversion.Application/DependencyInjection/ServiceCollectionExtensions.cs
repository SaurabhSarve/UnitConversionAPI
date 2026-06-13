using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using UnitConversion.Application.Interfaces;
using UnitConversion.Application.Services;
using UnitConversion.Application.Validators;

namespace UnitConversion.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<
            IConversionService,
            ConversionService>();

        services.AddValidatorsFromAssemblyContaining<
            ConversionRequestValidator>();

        return services;
    }
}