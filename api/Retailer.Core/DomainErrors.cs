using Retailer.Common;

namespace Retailer.Core;

public static class DomainErrors
{
    public static ValidationError InvalidPriceForSaleItem(decimal invalidPrice) =>
        new($"Invalid sale item price: {invalidPrice}");

    public static ValidationError InvalidQuantityForSaleItem(decimal invalidQuantity) =>
        new($"Invalid sale item quantity: {invalidQuantity}");

    public static ValidationError CannotCloseEmptySale() => new("Cannot close empty sale");

    public static ValidationError CannotAddItemToSaleThatIsNotInProgress() =>
        new("Cannot add item to a sale that is not in progress");
}