using NUnit.Framework;
using TaxCalculationLibrary.Implementation;

namespace TaxCalculationLibrary.Tests;

[TestFixture]
public class TaxCalculatorTests
{
    private TaxCalculator? _taxCalculator;
    
    [SetUp]
    public void SetUp()
    {
        _taxCalculator = new TaxCalculator();
    }
    
    [Test, Order(1)]
    public void GetCustomRates_CustomRateNotExistent_Null()
    {
        var firstCustomRate = _taxCalculator!.GetCustomRates().FirstOrDefault();
        
        Assert.That(firstCustomRate.Key, Is.Null);
        Assert.That(firstCustomRate.Value, Is.EqualTo(0));
    }

    [Test, Order(2)]
    public void SetCustomTaxRate_ShouldSetCustomRate()
    {
        _taxCalculator!.SetCustomTaxRate(Enums.Commodity.Alcohol, 10);
        
        var firstCustomRate = _taxCalculator!.GetCustomRates().First();
        
        Assert.That(firstCustomRate.Value, Is.EqualTo(10));
    }
    
    [Test, Order(3)]
    public void SetCustomTaxRate_ShouldUpdateCustomRate()
    {
        _taxCalculator!.SetCustomTaxRate(Enums.Commodity.Alcohol, 10);
        _taxCalculator!.SetCustomTaxRate(Enums.Commodity.Alcohol, 11);
        
        var firstCustomRate = _taxCalculator!.GetCustomRates().Last();
        
        Assert.That(firstCustomRate.Value, Is.EqualTo(11));
    }
    
    [Test, Order(4)]
    public void GetCurrentTaxRate_ShouldGetCustomRate()
    {
        _taxCalculator!.SetCustomTaxRate(Enums.Commodity.Alcohol, 13);
        
        var firstCustomRateValue = _taxCalculator!.GetCurrentTaxRate(Enums.Commodity.Alcohol);
        
        Assert.That(firstCustomRateValue, Is.EqualTo(13));
    }
    
    [Test, Order(5)]
    public void GetCurrentTaxRate_ShouldNotGetCustomRate()
    {
        Assert.DoesNotThrow(() => _taxCalculator!.GetCurrentTaxRate(Enums.Commodity.FoodServices));
    }
}