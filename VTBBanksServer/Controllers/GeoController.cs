using Microsoft.AspNetCore.Mvc;

using VTBBanksServer.Dtos;
using VTBBanksServer.Repository;
using VTBBanksServer.Util;



namespace VTBBanksServer.Controllers;

[ApiController]
[Route("[controller]/")]
public class GeoController : ControllerBase
{
    private BankOfficeRepository _salePointRepository;
    private CashMachineRepository _cashMachineRepository;

    public GeoController(BankOfficeRepository salePointRepository, CashMachineRepository cashMachineRepository)
    {
        _salePointRepository = salePointRepository;
        _cashMachineRepository = cashMachineRepository;
    }

    [HttpPost("nearest-bank-offices")]
    public IActionResult NearestBankOffices([FromBody] NearestbankDto nearestBankDto)
    {
        var result = _salePointRepository.GetNearestSalePoints(nearestBankDto);

        return Ok(result);
    }

    [HttpPost("nearest-bank-offices-opened")]
    public IActionResult NearestBankOfficesOpened([FromBody] NearestbankDto nearestBankDto)
    {
        var result = _salePointRepository.GetNearestOpenedSalePoints(nearestBankDto, DateTime.Now);

        return Ok(result);
    }

    [HttpGet("favourite-bank-office/{userId:int}")]
    public IActionResult FavouriteBankOffice(int userId)
    {
        var result = _salePointRepository.GetFavouriteBankOffices(userId);

        return Ok(result);
    }

    [HttpGet("favourite-cash-machine/{userId:int}")]
    public IActionResult FavouriteCashMachine(int userId)
    {
        var result = _salePointRepository.GetFavouriteCashMachines(userId);

        return Ok(result);
    }

    [HttpGet("bank-office-workload/{machineId:int}")]
    public IActionResult GetBankOfficeWorkload(int bankId)
    {
        var result = _salePointRepository.GetBankOfficeWorkload(bankId);

        return Ok(result);
    }

    [HttpGet("cash-machine-workload/{machineId:int}")]
    public IActionResult GetCashMachineWorkload(int machineId)
    {
        var result = _salePointRepository.GetCashMachineWorkload(machineId);

        return Ok(result);
    }
}
