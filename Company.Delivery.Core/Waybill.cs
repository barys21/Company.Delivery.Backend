namespace Company.Delivery.Core;

public class Waybill
{
    public Guid Id { get; set; }

    // TODO: уникальное значение
    public string Number { get; set; } = null!;

    public DateTime Date { get; set; }

    public ICollection<CargoItem>? Items { get; set; }
}