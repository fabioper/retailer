namespace Retailer.Application.DTOs;

public record SaleDTO(
    Guid Id,
    List<SaleItemDTO> Items,
    decimal Total,
    decimal Subtotal,
    decimal TotalDiscounts,
    List<AppliedDiscountDTO> AppliedDiscounts,
    string Status);
