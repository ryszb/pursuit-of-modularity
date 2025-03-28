using PursuitOfModularity.Logic;
using static PursuitOfModularity.Logic.PercentageDiscount;

var originalPrice = 99.99m;

var finalPrice1 = DiscountManager.ApplyDiscounts(originalPrice, [SpecialCustomerDiscount, RegularDiscount]);
var finalPrice2 = DiscountManager.ApplyDiscounts(originalPrice, [RegularDiscount, SpecialCustomerDiscount]);

Console.WriteLine($"Final price when applying SpecialCustomerDiscount then RegularDiscount: ${finalPrice1}");
Console.WriteLine($"Final price when applying RegularDiscount then SpecialCustomerDiscount: ${finalPrice2}");
