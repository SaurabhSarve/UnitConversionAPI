namespace UnitConversion.Application.Interfaces;

public interface IUnitConverter
{
    bool CanHandle(
        string fromUnit,
        string toUnit);

    double Convert(
        double value,
        string fromUnit,
        string toUnit);
}