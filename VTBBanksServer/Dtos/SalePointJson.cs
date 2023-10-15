using VTBBanksServer.Models;

namespace VTBBanksServer.Dtos;

public class SalePointJson
{
    public long Id { get; set; }
    public string SalePointName { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public List<OpenHoursJson> OpenHours { get; set; }
    public string Rko { get; set; }
    public List<OpenHoursJson> OpenHoursIndividual { get; set; }
    public string OfficeType { get; set; }
    public string SalePointFormat { get; set; }
    public string? SuoAvailability { get; set; }
    public string? HasRamp { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? MetroStation { get; set; }
    public int Distance { get; set; }
    public bool? Kep { get; set; }
    public bool MyBranch { get; set; }
}
