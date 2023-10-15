using VTBBanksServer.Data;
using VTBBanksServer.Models;

namespace VTBBanksServer.Repository;

public class CashMachineRepository
{
    private ApplicationDbContext _dbContext;

    public CashMachineRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddCashMachines(List<CashMachine> cashMachine)
    {
        _dbContext.CashMachines.AddRange(cashMachine);

        _dbContext.SaveChanges();
    }
}
