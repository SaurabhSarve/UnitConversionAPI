using UnitConversion.Application.Interfaces;
using UnitConversion.Domain.Constants;

namespace UnitConversion.Infrastructure.Converters;

public sealed class TemperatureConverter : IUnitConverter
{
    private static readonly string[] Units =
    [
        SupportedUnits.Celsius,
        SupportedUnits.Fahrenheit,
        SupportedUnits.Kelvin
    ];

    public bool CanHandle(
        string fromUnit,
        string toUnit)
    {
        return Units.Contains(
                   fromUnit,
                   StringComparer.OrdinalIgnoreCase)
               &&
               Units.Contains(
                   toUnit,
                   StringComparer.OrdinalIgnoreCase);
    }

    public double Convert(
        double value,
        string fromUnit,
        string toUnit)
    {
        fromUnit = fromUnit.ToLower();
        toUnit = toUnit.ToLower();

        if (fromUnit == toUnit)
            return value;

        double celsius = fromUnit switch
        {
            "celsius" => value,

            "fahrenheit" =>
                (value - 32) * 5 / 9,

            "kelvin" =>
                value - 273.15,

            _ => throw new InvalidOperationException()
        };

        return toUnit switch
        {
            "celsius" => celsius,

            "fahrenheit" =>
                (celsius * 9 / 5) + 32,

            "kelvin" =>
                celsius + 273.15,

            _ => throw new InvalidOperationException()
        };
    }
}