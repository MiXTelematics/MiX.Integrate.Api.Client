using System;

namespace MiX.Integrate.Shared.Entities.Fuel
{
  /// <summary>
  /// Definition of a fuel purchase transaction
  /// </summary>
  public class FuelTransaction
  {
  
    /// <summary>
    /// Id of the fuel purchase record
    /// </summary>
    public int FuelTransactionId { get; set; }
    
    /// <summary>
    /// Id of the asset to which the fuel purchase transaction applies
    /// </summary>
    public long AssetId { get; set; }

    /// <summary>
    /// The date time of the fuel purchase
    /// </summary>
    public DateTime FillDate { get; set; }

    /// <summary>
    /// Odometer of the asset at the time the fuel was purchased
    /// </summary>
    public decimal FillOdometerKilometres { get; set; }

    /// <summary>
    /// Quantity of fuel purchased, in litres
    /// </summary>
    public decimal Litres { get; set; }

    /// <summary>
    /// The asset's EngineHour reading at the time the fuel was purchased
    /// </summary>
    public int? FillEngineSeconds { get; set; }

    /// <summary>
    /// The code of the currency associated with the fuel purchase
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// The monetary cost of the fuel purchase transaction
    /// </summary>
    public decimal? Cost { get; set; }

    /// <summary>
    /// The base currency code of the fuel purchase
    /// </summary>
    public string BaseCurrency { get; set; }

    /// <summary>
    /// The monetary cost of the fuel purchase in base currency
    /// </summary>
    public decimal? BaseCost { get; set; }
    
    /// <summary>
    /// The location of the fuel purchase
    /// </summary>
    public string Location { get; set; }    
  }
}
