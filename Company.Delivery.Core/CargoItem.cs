using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Delivery.Core;

public class CargoItem
{
    public Guid Id { get; set; }

    public Guid WaybillId { get; set; }

    public Waybill? Waybill { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(10)]
    public string Number { get; set; } = null!;

    [MaxLength(10)]
    public string Name { get; set; } = null!;
}