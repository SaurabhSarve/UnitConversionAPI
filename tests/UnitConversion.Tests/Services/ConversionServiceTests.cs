using FluentAssertions;
using UnitConversion.Application.DTOs;
using UnitConversion.Application.Exceptions;
using UnitConversion.Application.Services;
using UnitConversion.Infrastructure.Converters;

namespace UnitConversion.Tests.Services;

public class ConversionServiceTests
{
    [Fact]
    public void Convert_Should_Return_Result()
    {
        var converters = new List<
            UnitConversion.Application.Interfaces.IUnitConverter>
        {
            new LengthConverter(),
            new WeightConverter(),
            new TemperatureConverter()
        };

        var service =
            new ConversionService(converters);

        var result =
            service.Convert(
                new ConversionRequest
                {
                    Value = 1,
                    FromUnit = "meter",
                    ToUnit = "foot"
                });

        result.ConvertedValue
            .Should()
            .BeApproximately(
                3.2808,
                0.001);
    }

    [Fact]
    public void Unsupported_Conversion_Should_Throw()
    {
        var converters = new List<
            UnitConversion.Application.Interfaces.IUnitConverter>
        {
            new LengthConverter()
        };

        var service =
            new ConversionService(converters);

        Action act = () =>
            service.Convert(
                new ConversionRequest
                {
                    Value = 10,
                    FromUnit = "meter",
                    ToUnit = "kilogram"
                });

        act.Should()
            .Throw<
                UnsupportedConversionException>();
    }
}