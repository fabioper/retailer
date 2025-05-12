namespace Retailer.Api.Models;

public record AddItemToSaleRequest(Guid ProductId, int Quantity);
