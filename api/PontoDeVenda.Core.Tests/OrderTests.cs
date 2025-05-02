using PontoDeVenda.Core.Order;

namespace PontoDeVenda.Core.Tests;

public class OrderTests
{
    [Test]
    public void ShouldCreateOrderWithInProgressStatus()
    {
        var order = Order.Order.Create().Value;
        Assert.That(order.Status, Is.EqualTo(OrderStatus.InProgress));
    }

    [Test]
    public void ShouldAddOrderItemToOrder()
    {
        var order = Order.Order.Create().Value;

        var addItemResult = order.AddItem(Guid.CreateVersion7(), 13, 1);

        Assert.Multiple(() =>
        {
            Assert.That(addItemResult.IsSuccess);
            Assert.That(order.Items, Has.Count.EqualTo(1));
        });
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-50.5)]
    public void ShoudlNotAddItemWithInvalidPrice(decimal invalidPrice)
    {
        var order = Order.Order.Create().Value;
        var result = order.AddItem(Guid.CreateVersion7(), invalidPrice, 1);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.HasError(DomainErrors.InvalidPriceForOrderItem(invalidPrice)));
        });
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-50)]
    public void ShoudlNotAddItemWithInvalidQuantity(int invalidQuantity)
    {
        var order = Order.Order.Create().Value;
        var result = order.AddItem(Guid.CreateVersion7(), 13, invalidQuantity);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.HasError(DomainErrors.InvalidQuantityForOrderItem(invalidQuantity)));
        });
    }

    [Test]
    public void ShouldUpdateTotalWhenOrderItemIsAdded()
    {
        var order = Order.Order.Create().Value;

        order.AddItem(Guid.CreateVersion7(), 5, 2);
        order.AddItem(Guid.CreateVersion7(), 15, 3);
        order.AddItem(Guid.CreateVersion7(), 300, 1);
        order.AddItem(Guid.CreateVersion7(), 12, 2);

        Assert.That(order.Total, Is.EqualTo(379));
    }

    [Test]
    public void ShouldCloseOrder()
    {
        var order = Order.Order.Create().Value;

        order.AddItem(Guid.CreateVersion7(), 5, 2);
        order.AddItem(Guid.CreateVersion7(), 15, 3);

        var closeOrderResult = order.Close();

        Assert.Multiple(() =>
        {
            Assert.That(closeOrderResult.IsSuccess);
            Assert.That(order.IsClosed());
        });
    }

    [Test]
    public void ShouldNotCloseOrderIfOrderIsEmpty()
    {
        var order = Order.Order.Create().Value;

        var closeOrderResult = order.Close();

        Assert.Multiple(() =>
        {
            Assert.That(closeOrderResult.IsSuccess, Is.False);
            Assert.That(closeOrderResult.HasError(DomainErrors.CannotCloseEmptyOrder()));
            Assert.That(!order.IsClosed());
        });
    }
}