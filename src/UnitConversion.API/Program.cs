using FluentValidation.AspNetCore;
using Serilog;
using UnitConversion.API.Extensions;
using UnitConversion.Application.DependencyInjection;
using UnitConversion.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .WriteTo.Console();
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseGlobalExceptionHandling();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();