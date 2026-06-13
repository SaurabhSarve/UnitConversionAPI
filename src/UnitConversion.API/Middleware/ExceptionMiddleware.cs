using System.Net;
using System.Text.Json;
using FluentValidation;
using UnitConversion.Application.DTOs;
using UnitConversion.Application.Exceptions;

namespace UnitConversion.API.Middleware;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(
        HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Unhandled exception occurred.");

            await HandleExceptionAsync(
                context,
                exception);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        context.Response.ContentType =
            "application/json";

        var response =
            new ErrorResponse
            {
                Success = false
            };

        switch (exception)
        {
            case ValidationException validationException:

                context.Response.StatusCode =
                    (int)HttpStatusCode.BadRequest;

                response = new ErrorResponse
                {
                    Success = false,
                    Message = "Validation failed.",
                    Errors = validationException.Errors
                        .Select(x => x.ErrorMessage)
                };

                break;

            case UnsupportedConversionException:

                context.Response.StatusCode =
                    (int)HttpStatusCode.BadRequest;

                response = new ErrorResponse
                {
                    Success = false,
                    Message = exception.Message
                };

                break;

            default:

                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                response = new ErrorResponse
                {
                    Success = false,
                    Message = "An unexpected error occurred."
                };

                break;
        }

        var json =
            JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}