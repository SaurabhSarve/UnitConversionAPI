namespace UnitConversion.Application.DTOs;

public sealed class ConversionResponse
{
    public double OriginalValue { get; init; }

    public string FromUnit { get; init; } = string.Empty;

    public string ToUnit { get; init; } = string.Empty;

    public double ConvertedValue { get; init; }
}