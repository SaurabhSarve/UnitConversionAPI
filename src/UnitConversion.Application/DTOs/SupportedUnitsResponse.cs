namespace UnitConversion.Application.DTOs;

public sealed class SupportedUnitsResponse
{
    public IEnumerable<string> Length { get; init; }
        = [];

    public IEnumerable<string> Weight { get; init; }
        = [];

    public IEnumerable<string> Temperature { get; init; }
        = [];
}