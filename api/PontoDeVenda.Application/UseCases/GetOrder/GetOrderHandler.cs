using PontoDeVenda.Application.DTOs;
using PontoDeVenda.Common;
using PontoDeVenda.Core.Order;
using static PontoDeVenda.Application.Mappers.OrderMapper;

namespace PontoDeVenda.Application.UseCases.GetOrder;

public class GetOrderHandler(IOrdersRepository repository) : IQueryHandler<Guid, OrderDTO>
{
    public async Task<Result<OrderDTO>> Execute(Guid orderId)
    {
        var order = await repository.GetByIdAsync(orderId);

        return order is null
            ? Result.Fail<OrderDTO>(CommonErrors.EntityNotFound(nameof(Order), orderId))
            : Result.Ok(MapOrderToDto(order));
    }
}