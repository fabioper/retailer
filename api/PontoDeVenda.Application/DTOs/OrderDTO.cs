namespace PontoDeVenda.Application.DTOs;

public record OrderDTO(
    Guid Id,
    List<OrderItemDTO> Items,
    decimal Total,
    string Status);