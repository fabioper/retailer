namespace Retailer.Application.DTOs;

public record SaleDTO(
    Guid Id,
    List<SaleItemDTO> Items,
    decimal Total,
    decimal Subtotal,
    decimal TotalDiscounts,
    List<DiscountDTO> Discounts,
    string Status);

public record DiscountDTO(Guid PolicyId, decimal Total);
