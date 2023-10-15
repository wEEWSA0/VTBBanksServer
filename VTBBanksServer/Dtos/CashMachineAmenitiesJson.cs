namespace VTBBanksServer.Dtos;

public class CashMachineAmenitiesJson
{
    public CashMachineAmenitiesPartJson Wheelchair { get; set; }
    public CashMachineAmenitiesPartJson Blind { get; set; }
    public CashMachineAmenitiesPartJson NfcForBankCards { get; set; }
    public CashMachineAmenitiesPartJson QrRead { get; set; }
    public CashMachineAmenitiesPartJson SupportsUsd { get; set; }
    public CashMachineAmenitiesPartJson SupportsChargeRub { get; set; }
    public CashMachineAmenitiesPartJson SupportsEur { get; set; }
    public CashMachineAmenitiesPartJson SupportsRub { get; set; }
}

public class CashMachineAmenitiesPartJson
{
    public string ServiceCapability { get; set; }
    public string ServiceActivity { get; set; }
}
