using Retailer.Core.DiscountPolicies.Conditions;
using Retailer.Core.DiscountPolicies.Policies;
using Retailer.Core.Sales;

namespace Retailer.Core.Tests;

public class SaleTests
{
    [Test]
    public void ShouldStartSaleWithInProgressStatus()
    {
        var sale = Sale.Start().Value;
        Assert.That(sale.IsInProgress);
    }

    [Test]
    public void ShouldAddSaleItemToSale()
    {
        var sale = Sale.Start().Value;

        var addItemResult = sale.AddItem(Guid.CreateVersion7(), 13, 1);

        Assert.Multiple(() =>
        {
            Assert.That(addItemResult.IsSuccess);
            Assert.That(sale.Items, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public void ShouldNotAddItemToSaleThatIsNotInProgress()
    {
        var sale = Sale.Start().Value;
        sale.AddItem(Guid.CreateVersion7(), 13, 1);

        sale.Complete();

        var addItemResult = sale.AddItem(Guid.CreateVersion7(), 13, 1);

        Assert.Multiple(() =>
        {
            Assert.That(addItemResult.IsFailed);
            Assert.That(sale.Items, Has.Count.EqualTo(1));
            Assert.That(addItemResult.HasError(DomainErrors.CannotAddItemToSaleThatIsNotInProgress()));
        });
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-50.5)]
    public void ShoudlNotAddItemWithInvalidPrice(decimal invalidPrice)
    {
        var sale = Sale.Start().Value;
        var result = sale.AddItem(Guid.CreateVersion7(), invalidPrice, 1);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.HasError(DomainErrors.InvalidPriceForSaleItem(invalidPrice)));
        });
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-50)]
    public void ShoudlNotAddItemWithInvalidQuantity(int invalidQuantity)
    {
        var sale = Sale.Start().Value;
        var result = sale.AddItem(Guid.CreateVersion7(), 13, invalidQuantity);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsFailed, Is.True);
            Assert.That(result.HasError(DomainErrors.InvalidQuantityForSaleItem(invalidQuantity)));
        });
    }

    [Test]
    public void ShouldUpdateTotalWhenItemIsAdded()
    {
        var sale = Sale.Start().Value;

        sale.AddItem(Guid.CreateVersion7(), 5, 2);
        sale.AddItem(Guid.CreateVersion7(), 15, 3);
        sale.AddItem(Guid.CreateVersion7(), 300, 1);
        sale.AddItem(Guid.CreateVersion7(), 12, 2);

        Assert.That(sale.Total, Is.EqualTo(379));
    }

    [Test]
    public void ShouldCompleteSale()
    {
        var sale = Sale.Start().Value;

        sale.AddItem(Guid.CreateVersion7(), 5, 2);
        sale.AddItem(Guid.CreateVersion7(), 15, 3);

        var completeSaleResult = sale.Complete();

        Assert.Multiple(() =>
        {
            Assert.That(completeSaleResult.IsSuccess);
            Assert.That(sale.IsCompleted);
        });
    }

    [Test]
    public void ShouldNotCompleteSaleWithNoItems()
    {
        var sale = Sale.Start().Value;

        var completeSaleResult = sale.Complete();

        Assert.Multiple(() =>
        {
            Assert.That(completeSaleResult.IsSuccess, Is.False);
            Assert.That(completeSaleResult.HasError(DomainErrors.CannotCloseEmptySale()));
            Assert.That(!sale.IsCompleted);
        });
    }

    [Test]
    public void ShouldApplyDiscountPolicy()
    {
        var sale = Sale.Start().Value;

        sale.AddItem(Guid.CreateVersion7(), 15, 1);
        sale.AddItem(Guid.CreateVersion7(), 5, 3);
        sale.AddItem(Guid.CreateVersion7(), 30, 1);

        var discountPolicy = new PercentageDiscountPolicy("TestPolicy", 10, true);

        discountPolicy.AddCondition(new MinimumTotalDiscountCondition(50));

        sale.ApplyDiscountPolicies([discountPolicy]);

        Assert.Multiple(() =>
        {
            Assert.That(sale.TotalDiscounts, Is.EqualTo(6));
            Assert.That(sale.Subtotal, Is.EqualTo(54));
        });
    }
}
