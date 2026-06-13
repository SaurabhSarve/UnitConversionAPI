namespace UnitConversion.API.Configurations;

public static class SwaggerExamples
{
    public static object ConversionRequest =>
        new
        {
            value = 100,
            fromUnit = "meter",
            toUnit = "foot"
        };
}