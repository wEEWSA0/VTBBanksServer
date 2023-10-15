using System.ComponentModel.DataAnnotations;

namespace VTBBanksServer.Dtos;

public class CashMachineJson
{
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool AllDay { get; set; }
    public CashMachineAmenitiesJson Services { get; set; }
}
