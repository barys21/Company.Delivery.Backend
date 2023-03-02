using AutoMapper;
using Company.Delivery.Api.Controllers.Waybills.Request;
using Company.Delivery.Api.Controllers.Waybills.Response;
using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Delivery.Api.Controllers.Waybills;

/// <summary>
/// Waybills management
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WaybillsController : ControllerBase
{
    private readonly IWaybillService _waybillService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Waybills management
    /// </summary>
    public WaybillsController(IWaybillService waybillService, IMapper mapper)
    {
        _waybillService = waybillService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получение Waybill
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _waybillService.GetByIdAsync(id, cancellationToken);
        var items = new List<CargoItemResponse>();
        if (result.Items != null)
        {
            foreach (var item in result.Items)
            {
                items.Add(new CargoItemResponse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    WaybillId = item.WaybillId,
                    Number = item.Number
                });
            }
        }

        var output = new WaybillResponse()
        {
            Id = result.Id,
            Date = result.Date,
            Number = result.Number,
            Items = items
        };

        return result == null ? NotFound() : Ok(output);
    }

    /// <summary>
    /// Создание Waybill
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] WaybillCreateRequest request, CancellationToken cancellationToken)
    {
        var input = _mapper.Map<WaybillCreateDto>(request);
        var result = await _waybillService.CreateAsync(input, cancellationToken);

        var items = new List<CargoItemResponse>();
        if (result != null)
        {
            if (result.Items != null)
            {
                foreach (var item in result.Items)
                {
                    items.Add(new CargoItemResponse()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        WaybillId = item.WaybillId,
                        Number = item.Number
                    });
                }
            }

            var output = new WaybillResponse()
            {
                Id = result.Id,
                Date = result.Date,
                Number = result.Number,
                Items = items
            };

            return Ok(output);
        }
        else
            return NotFound();
    }

    /// <summary>
    /// Редактирование Waybill
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateByIdAsync(Guid id, [FromBody] WaybillUpdateRequest request, CancellationToken cancellationToken)
    {
        var input = _mapper.Map<WaybillUpdateDto>(request);
        var result = await _waybillService.UpdateByIdAsync(id, input, cancellationToken);
        var items = new List<CargoItemResponse>();
        if (result != null)
        {
            if (result.Items != null)
            {
                foreach (var item in result.Items)
                {
                    items.Add(new CargoItemResponse()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        WaybillId = item.WaybillId,
                        Number = item.Number
                    });
                }
            }

            var output = new WaybillResponse()
            {
                Id = result.Id,
                Date = result.Date,
                Number = result.Number,
                Items = items
            };

            return Ok(output);
        }
        else
            return NotFound();
    }

    /// <summary>
    /// Удаление Waybill
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _waybillService.DeleteByIdAsync(id, cancellationToken);
            return Ok();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}