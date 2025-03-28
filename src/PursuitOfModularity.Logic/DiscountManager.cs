namespace PursuitOfModularity.Logic;

public static class DiscountManager
{
    public static decimal ApplyDiscounts(decimal originalPrice, IList<IDiscount> _discounts)
    {
        var finalPrice = originalPrice;

        foreach (var discount in _discounts)
        {
            finalPrice = discount.ApplyDiscount(finalPrice);
        }

        return finalPrice;
    }
}