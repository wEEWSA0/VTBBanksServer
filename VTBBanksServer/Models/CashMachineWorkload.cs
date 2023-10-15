using Microsoft.EntityFrameworkCore;

namespace VTBBanksServer.Models;

[PrimaryKey(nameof(CashMachineId), nameof(Date))]
public class CashMachineWorkload
{
    public long CashMachineId { get; set; }
    public CashMachine CashMachine { get; set; }

    public DateTime Date { get; set; }

    // За определенный период времени
    public int OperationsCount { get; set; } // данные с системы - количество операций/оказанных услуг за период
    public int PeopleVisited { get; set; } // данные с камер - всего людей за период
    public int PeopleLeft { get; set; } // данные с камер - количество людей на момент создания данных

    // OperationsCount / (PeopleVisited - PeopleLeft) - кпд за период работы
}
