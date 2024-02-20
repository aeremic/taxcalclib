using System.Globalization;

namespace TaxCalculationLibrary.Implementation;

using Commodity = Enums.Commodity;

/// <summary>
/// Implements a tax calculator for our client.
/// The calculator has a set of standard tax rates that are hard-coded in the class.
/// It also allows our client to remotely set new, custom tax rates.
/// Finally, it allows the fetching of tax rate information for a specific commodity and point in time.
/// There are also a number of things that have to be implemented.
/// </summary>
public class TaxCalculator : ITaxCalculator
{
    #region Properties

    private static readonly Dictionary<Tuple<Commodity, string>, double> CustomRates = new();

    #endregion

    #region ITaxCalculator implementation

    public double GetStandardTaxRate(Commodity commodity)
    {
        switch (commodity)
        {
            case Commodity.Default:
            case Commodity.Alcohol:
                return 0.25;
            case Commodity.Food:
            case Commodity.FoodServices:
                return 0.12;
            case Commodity.Literature:
            case Commodity.Transport:
            case Commodity.CulturalServices:
                return 0.6;
            default:
                return 0.25;
        }
    }

    public void SetCustomTaxRate(Commodity commodity, double rate)
    {
        var customRateKey = Tuple.Create(commodity, DateTime.Now.ToString(CultureInfo.InvariantCulture));

        CustomRates[customRateKey] = rate;
    }

    public double GetTaxRateForDateTime(Commodity commodity, DateTime date)
    {
        var customRateKey = Tuple.Create(commodity, date.ToString(CultureInfo.InvariantCulture));

        return CustomRates.GetValueOrDefault(customRateKey);
    }

    public double GetCurrentTaxRate(Commodity commodity)
    {
        var customRateKey = Tuple.Create(commodity, DateTime.Now.ToString(CultureInfo.InvariantCulture));

        return CustomRates.GetValueOrDefault(customRateKey);
    }

    public Dictionary<Tuple<Commodity, string>, double> GetCustomRates()
    {
        return CustomRates;
    }

    #endregion
}