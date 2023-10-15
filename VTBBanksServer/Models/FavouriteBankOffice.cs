using Microsoft.EntityFrameworkCore;

namespace VTBBanksServer.Models;

[PrimaryKey(nameof(UserId), nameof(BankOfficeId))]
public class FavouriteBankOffice
{
    public int UserId { get; set; }
    public User User { get; set; }
    public long BankOfficeId { get; set; }
    public BankOffice BankOffice { get; set; }
}
