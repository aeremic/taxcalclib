namespace TaxCalculationLibrary.Implementation;

public static class Enums
{
    /// <summary>
    /// These are the actual tax rates that should apply, we just got them from the client!
    /// </summary>
    public enum Commodity
    {
        Default, // 25%
        Alcohol, // 25%
        Food, // 12%
        FoodServices, // 12%
        Literature, // 6%
        Transport, // 6%
        CulturalServices // 6%
    }
}