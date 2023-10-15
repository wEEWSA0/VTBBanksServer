using VTBBanksServer.Models;

namespace VTBBanksServer.Dtos;

public class OpenHoursJson
{
    public long SalePointId { get; set; }

    public string Days { get; set; }
    public string Hours { get; set; }
}
