using Company.Delivery.Core;
using Company.Delivery.Database;
using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace Company.Delivery.Infrastructure;

public class WaybillService : IWaybillService
{
    protected DeliveryDbContext _dbContext;

    public WaybillService(DeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<WaybillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Waybills
            .Include(e => e.Items)
            .Where(e => e.Id == id)
            .Select(x => new WaybillDto
            {
                Id = x.Id,
                Number = x.Number,
                Date = x.Date,
                Items = x.Items != null ? (IEnumerable<CargoItemDto>)x.Items : null

            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (result != null)
            return await Task.FromResult(result);
        else
            throw new EntityNotFoundException();
    }

    public async Task<WaybillDto> CreateAsync(WaybillCreateDto data, CancellationToken cancellationToken)
    {
        var waybill = new Waybill()
        {
            Number = data.Number,
            Date = data.Date,
            Items = data.Items != null ? (ICollection<CargoItem>)data.Items : null
        };

        _dbContext.Waybills.Add(waybill);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var result = new WaybillDto
        {
            Id = waybill.Id,
            Number = waybill.Number,
            Date = waybill.Date,
            Items = waybill.Items != null ? (IEnumerable<CargoItemDto>)waybill.Items : null
        };

        return await Task.FromResult(result);
    }

    public async Task<WaybillDto> UpdateByIdAsync(Guid id, WaybillUpdateDto data, CancellationToken cancellationToken)
    {
        var waybill = _dbContext.Waybills.Include(e => e.Items).FirstOrDefault(e => e.Id == id);
        if (waybill == null)
            throw new EntityNotFoundException();

        waybill.Number = data.Number;
        waybill.Date = data.Date;
        waybill.Items = (ICollection<Core.CargoItem>?)data.Items;

        _dbContext.Waybills.Update(waybill);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var waybillDto = new WaybillDto
        {
            Id = waybill.Id,
            Number = waybill.Number,
            Date = waybill.Date,
            Items = waybill.Items != null ? (IEnumerable<CargoItemDto>)waybill.Items : null
        };

        return await Task.FromResult(waybillDto);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var waybill = await _dbContext.Waybills.FirstOrDefaultAsync(e => e.Id == id, cancellationToken: cancellationToken);
        if (waybill == null)
            throw new EntityNotFoundException();

        _dbContext.Waybills.Remove(waybill);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}