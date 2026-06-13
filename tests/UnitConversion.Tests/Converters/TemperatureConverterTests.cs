using FluentAssertions;
using UnitConversion.Infrastructure.Converters;

namespace UnitConversion.Tests.Converters;

public class TemperatureConverterTests
{
    private readonly TemperatureConverter _converter =
        new();

    [Fact]
    public void Celsius_To_Fahrenheit()
    {
        var result =
            _converter.Convert(
                0,
                "celsius",
                "fahrenheit");

        result.Should().Be(32);
    }

    [Fact]
    public void Celsius_To_Kelvin()
    {
        var result =
            _converter.Convert(
                0,
                "celsius",
                "kelvin");

        result.Should()
            .BeApproximately(
                273.15,
                0.001);
    }

    [Fact]
    public void Fahrenheit_To_Celsius()
    {
        var result =
            _converter.Convert(
                32,
                "fahrenheit",
                "celsius");

        result.Should()
            .BeApproximately(
                0,
                0.001);
    }
}