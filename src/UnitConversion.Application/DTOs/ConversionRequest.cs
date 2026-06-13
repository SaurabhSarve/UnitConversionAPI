namespace UnitConversion.Application.DTOs;

public sealed class ConversionRequest
{
    public double Value { get; init; }

    public string FromUnit { get; init; } = string.Empty;

    public string ToUnit { get; init; } = string.Empty;
}