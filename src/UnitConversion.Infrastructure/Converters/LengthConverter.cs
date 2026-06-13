using UnitConversion.Application.Interfaces;
using UnitConversion.Domain.Constants;

namespace UnitConversion.Infrastructure.Converters;

public sealed class LengthConverter : IUnitConverter
{
    private static readonly Dictionary<string, double> Factors =
        new(StringComparer.OrdinalIgnoreCase)
        {
            [SupportedUnits.Meter] = 1,
            [SupportedUnits.Kilometer] = 1000,
            [SupportedUnits.Centimeter] = 0.01,
            [SupportedUnits.Foot] = 0.3048,
            [SupportedUnits.Inch] = 0.0254,
            [SupportedUnits.Mile] = 1609.344
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
        var baseValue =
            value * Factors[fromUnit];

        return baseValue /
               Factors[toUnit];
    }
}