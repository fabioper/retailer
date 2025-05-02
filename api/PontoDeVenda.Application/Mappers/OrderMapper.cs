using PontoDeVenda.Application.DTOs;
using PontoDeVenda.Core.Order;

namespace PontoDeVenda.Application.Mappers;

public static class OrderMapper
{
    public static OrderDTO MapOrderToDto(Order order) => new(
        order.Id,
        order.Items.Select(MapOrderItemToDto).ToList(),
        order.Total,
        order.Status.ToString());

    private static OrderItemDTO MapOrderItemToDto(OrderItem item) => new(item.Id, item.Price, item.Quantity);
}