using FluentAssertions;
using UnitConversion.Infrastructure.Converters;

namespace UnitConversion.Tests.Converters;

public class LengthConverterTests
{
    private readonly LengthConverter _converter =
        new();

    [Fact]
    public void Meter_To_Foot()
    {
        var result =
            _converter.Convert(
                1,
                "meter",
                "foot");

        result.Should()
            .BeApproximately(
                3.28084,
                0.001);
    }

    [Fact]
    public void Kilometer_To_Meter()
    {
        var result =
            _converter.Convert(
                1,
                "kilometer",
                "meter");

        result.Should().Be(1000);
    }

    [Fact]
    public void Mile_To_Kilometer()
    {
        var result =
            _converter.Convert(
                1,
                "mile",
                "kilometer");

        result.Should()
            .BeApproximately(
                1.60934,
                0.001);
    }
}