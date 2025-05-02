namespace PontoDeVenda.Application.DTOs;

public record OrderItemDTO(Guid Id, decimal Price, int Quantity);