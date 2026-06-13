using UnitConversion.Application.DTOs;
using UnitConversion.Application.Exceptions;
using UnitConversion.Application.Interfaces;
using UnitConversion.Domain.Constants;
using UnitConversion.Domain.Enums;

namespace UnitConversion.Application.Services;

public sealed class ConversionService : IConversionService
{
    private readonly IEnumerable<IUnitConverter> _converters;

    public ConversionService(
        IEnumerable<IUnitConverter> converters)
    {
        _converters = converters;
    }

    public ConversionResponse Convert(
        ConversionRequest request)
    {
        var converter =
            _converters.FirstOrDefault(
                c => c.CanHandle(
                    request.FromUnit,
                    request.ToUnit));

        if (converter is null)
        {
            throw new UnsupportedConversionException(
                request.FromUnit,
                request.ToUnit);
        }

        var result =
            converter.Convert(
                request.Value,
                request.FromUnit,
                request.ToUnit);

        return new ConversionResponse
        {
            OriginalValue = request.Value,
            FromUnit = request.FromUnit,
            ToUnit = request.ToUnit,
            ConvertedValue = Math.Round(
                result,
                4)
        };
    }

    public SupportedUnitsResponse GetSupportedUnits()
    {
        return new SupportedUnitsResponse
        {
            Length = UnitCatalog.Units
                .Where(x =>
                    x.Category ==
                    UnitCategory.Length)
                .Select(x => x.Name),

            Weight = UnitCatalog.Units
                .Where(x =>
                    x.Category ==
                    UnitCategory.Weight)
                .Select(x => x.Name),

            Temperature = UnitCatalog.Units
                .Where(x =>
                    x.Category ==
                    UnitCategory.Temperature)
                .Select(x => x.Name)
        };
    }
}