using Microsoft.AspNetCore.Mvc;
using UnitConversion.Application.DTOs;
using UnitConversion.Application.Interfaces;

namespace UnitConversion.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class ConversionsController : ControllerBase
{
    private readonly IConversionService _conversionService;

    public ConversionsController(
        IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    /// <summary>
    /// Convert a value from one unit to another
    /// </summary>
    [HttpPost]
    [ProducesResponseType(
        typeof(ConversionResponse),
        StatusCodes.Status200OK)]
    [ProducesResponseType(
        StatusCodes.Status400BadRequest)]
    public ActionResult<ConversionResponse> Convert(
        [FromBody] ConversionRequest request)
    {
        var result =
            _conversionService.Convert(request);

        return Ok(result);
    }

    /// <summary>
    /// Get all supported units
    /// </summary>
    [HttpGet("units")]
    [ProducesResponseType(
        typeof(SupportedUnitsResponse),
        StatusCodes.Status200OK)]
    public ActionResult<SupportedUnitsResponse>
        GetSupportedUnits()
    {
        var result =
            _conversionService.GetSupportedUnits();

        return Ok(result);
    }
}