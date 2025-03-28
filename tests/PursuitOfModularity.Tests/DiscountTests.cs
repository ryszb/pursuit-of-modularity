using FluentAssertions;
using PursuitOfModularity.Logic;
using static PursuitOfModularity.Logic.PercentageDiscount;

namespace PursuitOfModularity.Tests;

public class DiscountTests
{
    [Fact]
    public void ApplySpecialCustomerDiscount()
    {
        var originalPrice = 100m;

        var finalPrice = SpecialCustomerDiscount.ApplyDiscount(originalPrice);

        finalPrice.Should().Be(95.55m); // expected result after applying 4.45% discount
    }

    [Fact]
    public void ApplyRegularDiscount()
    {
        var originalPrice = 100m;

        var finalPrice = RegularDiscount.ApplyDiscount(originalPrice);

        finalPrice.Should().Be(67m); // expected result after applying 33% discount
    }

    [Fact]
    public void ApplyNotPredefinedDiscount()
    {
        var originalPrice = 100m;
        var percentageDiscount = 25m;

        var finalPrice = new PercentageDiscount(percentageDiscount).ApplyDiscount(originalPrice);

        finalPrice.Should().Be(75m);
    }

    [Theory]
    [MemberData(nameof(DiscountTable))]
    public void ApplyTwoDiscounts(decimal originalPrice, IDiscount firstDiscount, IDiscount secondDiscount, decimal expectedFinalPrice)
    {
        var finalPrice = DiscountManager.ApplyDiscounts(originalPrice, [firstDiscount, secondDiscount]);

        finalPrice.Should().Be(expectedFinalPrice);
    }

    public static IEnumerable<object[]> DiscountTable()
    {
        yield return [100m, SpecialCustomerDiscount, RegularDiscount, 64.01m];
        yield return [100m, RegularDiscount, SpecialCustomerDiscount, 64.01m];
    }
}
