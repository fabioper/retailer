namespace Retailer.Application.DTOs;

public record SaleDTO(
    Guid Id,
    List<SaleItemDTO> Items,
    decimal Total,
    string Status);