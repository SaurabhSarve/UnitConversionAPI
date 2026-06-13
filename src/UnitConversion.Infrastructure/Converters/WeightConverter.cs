using UnitConversion.Application.Interfaces;
using UnitConversion.Domain.Constants;

namespace UnitConversion.Infrastructure.Converters;

public sealed class WeightConverter : IUnitConverter
{
    private static readonly Dictionary<string, double> Factors =
        new(StringComparer.OrdinalIgnoreCase)
        {
            [SupportedUnits.Kilogram] = 1,
            [SupportedUnits.Gram] = 0.001,
            [SupportedUnits.Pound] = 0.45359237,
            [SupportedUnits.Ounce] = 0.0283495231
        };

    public bool CanHandle(
        string fromUnit,
        string toUnit)
    {
        return Factors.ContainsKey(fromUnit)
               && Factors.ContainsKey(toUnit);
    }

    public double Convert(
        double value,
        string fromUnit,
        string toUnit)
    {
        var kilograms =
            value * Factors[fromUnit];

        return kilograms /
               Factors[toUnit];
    }
}