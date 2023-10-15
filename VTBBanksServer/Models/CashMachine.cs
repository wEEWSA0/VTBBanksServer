using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

using VTBBanksServer.Dtos;

namespace VTBBanksServer.Models;

[PrimaryKey(nameof(Id), nameof(Address))]
public class CashMachine
{
    public long Id { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool AllDay { get; set; }
    public List<CashMachineAmenities> Amenities { get; set; }
}
