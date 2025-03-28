namespace PursuitOfModularity.Logic;

public class PercentageDiscount : IDiscount
{
    private readonly decimal _discountPercentage;

    public static PercentageDiscount SpecialCustomerDiscount => new(4.45m);
    public static PercentageDiscount RegularDiscount => new(33);

    public PercentageDiscount(decimal discountPercentage) => _discountPercentage = discountPercentage;

    public decimal ApplyDiscount(decimal originalPrice)
    {
        var finalPrice = originalPrice * (100 - _discountPercentage) / 100;

        return Math.Round(finalPrice, 2, MidpointRounding.ToZero);
    }
}