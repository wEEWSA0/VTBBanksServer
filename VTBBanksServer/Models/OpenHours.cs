using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

using VTBBanksServer.Util;

namespace VTBBanksServer.Models;

[PrimaryKey(nameof(SalePointId), nameof(Type), nameof(Day))]
public class OpenHours
{
    public long SalePointId { get; set; }
    public BankOffice SalePoint { get; set; }
    public OpenHoursType Type { get; set; }

    public Day Day { get; set; }
    public TimeOnly OpenHour { get; set; }
    public TimeOnly CloseHour { get; set; }
}
