namespace UnitConversion.Application.Exceptions;

public sealed class UnsupportedConversionException
    : Exception
{
    public UnsupportedConversionException(
        string fromUnit,
        string toUnit)
        : base(
            $"Conversion from '{fromUnit}' to '{toUnit}' is not supported.")
    {
    }
}