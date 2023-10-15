using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

using VTBBanksServer.Data;
using VTBBanksServer.Dtos;
using VTBBanksServer.Models;

namespace VTBBanksServer.Repository;

public class BankOfficeRepository
{
    private ApplicationDbContext _dbContext;

    public BankOfficeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddSalePoints(List<BankOffice> salePoints)
    {
        _dbContext.BankOffices.AddRange(salePoints);

        _dbContext.SaveChanges();
    }

    public List<BankOffice> GetNearestSalePoints(NearestbankDto nearestBankDto)
    {
        return _dbContext.BankOffices.Where(x => 
        (x.Latitude < nearestBankDto.Radius + nearestBankDto.UserLatitude
        && x.Latitude > - nearestBankDto.Radius + nearestBankDto.UserLatitude) &&
        (x.Longitude < nearestBankDto.Radius + nearestBankDto.UserLongitude
        && x.Longitude > -nearestBankDto.Radius + nearestBankDto.UserLongitude)).ToList();
    }

    public List<BankOffice> GetNearestOpenedSalePoints(NearestbankDto nearestBankDto, DateTime time)
    {
        var salePoints = _dbContext.BankOffices.Where(x =>
        (x.Latitude < nearestBankDto.Radius + nearestBankDto.UserLatitude
        && x.Latitude > -nearestBankDto.Radius + nearestBankDto.UserLatitude) &&
        (x.Longitude < nearestBankDto.Radius + nearestBankDto.UserLongitude
        && x.Longitude > -nearestBankDto.Radius + nearestBankDto.UserLongitude) &&
        x.OpenHours.Where(n => (int)n.Day == int.Parse(time.DayOfWeek.ToString("d"))).FirstOrDefault() != null).ToList();

        foreach (var salePoint in salePoints)
        {
            var day = salePoint.OpenHours.Where(n => (int)n.Day == int.Parse(time.DayOfWeek.ToString("d"))).First();

            if (time.Hour < day.OpenHour.Hour && time.Hour > day.CloseHour.Hour)
            {
                salePoints.Remove(salePoint);

                continue;
            }
        }

        return salePoints;
    }

    public List<BankOffice> GetFavouriteBankOffices(int userId)
    {
        return _dbContext.FavouriteBankOffices.Where(x => x.UserId == userId)
            .Include(z => z.BankOffice)
            .Select(z => z.BankOffice)
            .ToList();
    }

    public List<CashMachine> GetFavouriteCashMachines(int userId)
    {
        return _dbContext.FavouriteCashMachines.Where(x => x.UserId == userId)
            .Include(z => z.CashMachine)
            .Select(z => z.CashMachine)
            .ToList();
    }

    public BankOfficeWorkload GetBankOfficeWorkload(int id)
    {
        return _dbContext.BankOfficeWorkloads.Where(x => x.BankOfficeId == id)
            .OrderByDescending(x => x.Date)
            .FirstOrDefault();
    }

    public CashMachineWorkload GetCashMachineWorkload(int id)
    {
        return _dbContext.CashMachineWorkloads.Where(x => x.CashMachineId == id)
            .OrderByDescending(x => x.Date)
            .FirstOrDefault();
    }
}
