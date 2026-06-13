using FluentAssertions;
using UnitConversion.Infrastructure.Converters;

namespace UnitConversion.Tests.Converters;

public class WeightConverterTests
{
    private readonly WeightConverter _converter =
        new();

    [Fact]
    public void Kilogram_To_Pound()
    {
        var result =
            _converter.Convert(
                1,
                "kilogram",
                "pound");

        result.Should()
            .BeApproximately(
                2.20462,
                0.001);
    }

    [Fact]
    public void Gram_To_Kilogram()
    {
        var result =
            _converter.Convert(
                1000,
                "gram",
                "kilogram");

        result.Should().Be(1);
    }

    [Fact]
    public void Pound_To_Ounce()
    {
        var result =
            _converter.Convert(
                1,
                "pound",
                "ounce");

        result.Should()
            .BeApproximately(
                16,
                0.01);
    }
}