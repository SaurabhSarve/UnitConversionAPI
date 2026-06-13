using UnitConversion.Domain.Enums;

namespace UnitConversion.Domain.Entities;

public class UnitDefinition
{
    public string Name { get; init; } = string.Empty;

    public string Symbol { get; init; } = string.Empty;

    public UnitCategory Category { get; init; }
}