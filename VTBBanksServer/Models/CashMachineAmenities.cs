using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace VTBBanksServer.Models;

[PrimaryKey(nameof(CashMachineId), nameof(Name))]
public class CashMachineAmenities
{
    public long CashMachineId { get; set; }
    public string Name { get; set; }
    public bool Capability { get; set; }
    public bool Activity { get; set; }
}
