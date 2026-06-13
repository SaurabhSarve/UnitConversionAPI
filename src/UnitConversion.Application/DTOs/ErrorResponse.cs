namespace UnitConversion.Application.DTOs;

public sealed class ErrorResponse
{
    public bool Success { get; init; }

    public string Message { get; init; }
        = string.Empty;

    public IEnumerable<string>? Errors { get; init; }
}