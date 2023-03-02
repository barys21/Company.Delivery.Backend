using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;

namespace Company.Delivery.Infrastructure;

public class WaybillService : IWaybillService
{
    public Task<WaybillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // TODO: Если сущность не найдена по идентификатору, кинуть исключение типа EntityNotFoundException

        throw new NotImplementedException();
    }

    public Task<WaybillDto> CreateAsync(WaybillCreateDto data, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<WaybillDto> UpdateByIdAsync(Guid id, WaybillUpdateDto data, CancellationToken cancellationToken)
    {
        // TODO: Если сущность не найдена по идентификатору, кинуть исключение типа EntityNotFoundException

        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // TODO: Если сущность не найдена по идентификатору, кинуть исключение типа EntityNotFoundException

        throw new NotImplementedException();
    }
}