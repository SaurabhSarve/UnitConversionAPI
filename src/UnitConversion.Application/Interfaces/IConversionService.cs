using UnitConversion.Application.DTOs;

namespace UnitConversion.Application.Interfaces;

public interface IConversionService
{
    ConversionResponse Convert(
        ConversionRequest request);

    SupportedUnitsResponse GetSupportedUnits();
}