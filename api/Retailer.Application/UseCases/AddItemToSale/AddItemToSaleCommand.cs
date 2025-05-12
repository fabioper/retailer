namespace Retailer.Application.UseCases.AddItemToSale;

public record AddItemToSaleCommand(Guid SaleId, Guid ProductId, int Quantity);
