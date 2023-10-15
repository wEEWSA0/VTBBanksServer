using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using VTBBanksServer.Models;

namespace VTBBanksServer.Data;
public class ApplicationDbContext : IdentityDbContext<User, Role, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<BankOffice> BankOffices { get; set; }
    public DbSet<OpenHours> OpenHours { get; set; }
    public DbSet<CashMachine> CashMachines { get; set; }
    public DbSet<CashMachineAmenities> CashMachineAmenities { get; set; }

    public DbSet<FavouriteBankOffice> FavouriteBankOffices { get; set; }
    public DbSet<FavouriteCashMachine> FavouriteCashMachines { get; set; }

    public DbSet<BankOfficeWorkload> BankOfficeWorkloads { get; set; }
    public DbSet<CashMachineWorkload> CashMachineWorkloads { get; set; }
}
