namespace TaxCalculationLibrary.Implementation;

using Commodity = Enums.Commodity;

/// <summary>
/// This is the public interface used by our client and may not be changed
/// </summary>
public interface ITaxCalculator
{
    /// <summary>
    /// Get the standard tax rate for a specific commodity.
    /// </summary>
    public double GetStandardTaxRate(Commodity commodity);
    
    /// <summary>
    /// This method allows the client to remotely set new custom tax rates.
    /// When they do, we save the commodity/rate information as well as the UTC timestamp of when it was done.
    /// NOTE: Each instance of this object supports a different set of custom rates, since we run one thread per customer.
    /// </summary>
    public void SetCustomTaxRate(Commodity commodity, double rate);
    
    /// <summary>
    /// Gets the tax rate that is active for a specific point in time (in UTC).
    /// A custom tax rate is seen as the currently active rate for a period from its starting timestamp until a new custom rate is set.
    /// If there is no custom tax rate for the specified date, use the standard tax rate.
    /// </summary>
    public double GetTaxRateForDateTime(Commodity commodity, DateTime date);
    
    /// <summary>
    /// Gets the tax rate that is active for the current point in time.
    /// A custom tax rate is seen as the currently active rate for a period from its starting timestamp until a new custom rate is set.
    /// If there is no custom tax currently active, use the standard tax rate.
    /// </summary>
    public double GetCurrentTaxRate(Commodity commodity);

    /// <summary>
    /// Gets the set custom rates.
    /// </summary>
    public Dictionary<Tuple<Commodity, string>, double> GetCustomRates();
}