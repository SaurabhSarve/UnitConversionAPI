using UnitConversion.Domain.Entities;
using UnitConversion.Domain.Enums;

namespace UnitConversion.Domain.Constants;

public static class UnitCatalog
{
    public static readonly IReadOnlyList<UnitDefinition> Units =
    [
        new()
        {
            Name = SupportedUnits.Meter,
            Symbol = "m",
            Category = UnitCategory.Length
        },

        new()
        {
            Name = SupportedUnits.Kilometer,
            Symbol = "km",
            Category = UnitCategory.Length
        },

        new()
        {
            Name = SupportedUnits.Centimeter,
            Symbol = "cm",
            Category = UnitCategory.Length
        },

        new()
        {
            Name = SupportedUnits.Foot,
            Symbol = "ft",
            Category = UnitCategory.Length
        },

        new()
        {
            Name = SupportedUnits.Inch,
            Symbol = "in",
            Category = UnitCategory.Length
        },

        new()
        {
            Name = SupportedUnits.Mile,
            Symbol = "mi",
            Category = UnitCategory.Length
        },

        new()
        {
            Name = SupportedUnits.Kilogram,
            Symbol = "kg",
            Category = UnitCategory.Weight
        },

        new()
        {
            Name = SupportedUnits.Gram,
            Symbol = "g",
            Category = UnitCategory.Weight
        },

        new()
        {
            Name = SupportedUnits.Pound,
            Symbol = "lb",
            Category = UnitCategory.Weight
        },

        new()
        {
            Name = SupportedUnits.Ounce,
            Symbol = "oz",
            Category = UnitCategory.Weight
        },

        new()
        {
            Name = SupportedUnits.Celsius,
            Symbol = "°C",
            Category = UnitCategory.Temperature
        },

        new()
        {
            Name = SupportedUnits.Fahrenheit,
            Symbol = "°F",
            Category = UnitCategory.Temperature
        },

        new()
        {
            Name = SupportedUnits.Kelvin,
            Symbol = "K",
            Category = UnitCategory.Temperature
        }
    ];
}