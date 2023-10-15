using Microsoft.AspNetCore.Mvc;

using VTBBanksServer.Repository;
using VTBBanksServer.Util;

namespace VTBBanksServer.Controllers;

[ApiController]
[Route("[controller]/")]
public class SetupDatabaseController : ControllerBase
{
    private BankOfficeRepository _salePointRepository;
    private CashMachineRepository _cashMachineRepository;

    public SetupDatabaseController(BankOfficeRepository salePointRepository, CashMachineRepository cashMachineRepository)
    {
        _salePointRepository = salePointRepository;
        _cashMachineRepository = cashMachineRepository;
    }

    [HttpGet("Offices")]
    public IActionResult CreateOfficies()
    {
        var parser = new OfficesJsonToPostgresSql(_salePointRepository);

        parser.UpdateOfficesTablesInDatabase();

        return Ok();
    }

    [HttpGet("ATMS")]
    public IActionResult CreateATMS()
    {
        var parser = new ATMSJsonToPostgresSql(_cashMachineRepository);

        parser.UpdateATMSTablesInDatabase();

        return Ok();
    }
}
