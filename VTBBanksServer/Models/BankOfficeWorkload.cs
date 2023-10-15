using Microsoft.EntityFrameworkCore;

namespace VTBBanksServer.Models;

[PrimaryKey(nameof(BankOfficeId), nameof(Date))]
public class BankOfficeWorkload
{
    public long BankOfficeId { get; set; }
    public BankOffice BankOffice { get; set; }

    public DateTime Date { get; set; }

    // За определенный период времени
    public int OperationsCount { get; set; } // данные с системы - количество операций/оказанных услуг за период
    public int PeopleVisited { get; set; } // данные с камер - всего людей за период
    public int PeopleLeft { get; set; } // данные с камер - количество людей на момент создания данных

    // OperationsCount / (PeopleVisited - PeopleLeft) - кпд за период работы
}
