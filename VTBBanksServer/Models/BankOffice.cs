using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace VTBBanksServer.Models;

[PrimaryKey(nameof(Id), nameof(Name))]
public class BankOffice
{
    //[Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public List<OpenHours> OpenHours { get; set; }
    public string? Rko { get; set; }
    public string? OfficeType { get; set; }
    public string? SalePointFormat { get; set; }
    public string? SuoAvailability { get; set; }
    public string? HasRamp { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? MetroStation { get; set; }
    public int Distance { get; set; }
    public bool? Kep { get; set; }
    public bool MyBranch { get; set; }
}
