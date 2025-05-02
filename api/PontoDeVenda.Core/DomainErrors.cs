using PontoDeVenda.Common;

namespace PontoDeVenda.Core;

public static class DomainErrors
{
    public static ValidationError InvalidPriceForOrderItem(decimal invalidPrice) =>
        new($"Invalid order item price: {invalidPrice}");

    public static ValidationError InvalidQuantityForOrderItem(decimal invalidQuantity) =>
        new($"Invalid order item quantity: {invalidQuantity}");

    public static ValidationError CannotCloseEmptyOrder() => new($"Cannot close empty order");
}