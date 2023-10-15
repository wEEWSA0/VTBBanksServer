using Microsoft.EntityFrameworkCore;

namespace VTBBanksServer.Models;

[PrimaryKey(nameof(UserId), nameof(CashMachineId))]
public class FavouriteCashMachine
{
    public int UserId { get; set; }
    public User User { get; set; }
    public long CashMachineId { get; set; }
    public CashMachine CashMachine { get; set; }
}
