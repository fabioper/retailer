using PontoDeVenda.Application.DTOs;
using PontoDeVenda.Common;
using PontoDeVenda.Core.Order;
using static PontoDeVenda.Application.Mappers.OrderMapper;

namespace PontoDeVenda.Application.UseCases.CreateOrder;

public class CreateOrderHandler(IOrdersRepository repository) : IUseCase<OrderDTO>
{
    public async Task<Result<OrderDTO>> Execute()
    {
        var createOrderResult = Order.Create();

        if (createOrderResult.IsFailed)
            return Result.Fail<OrderDTO>(createOrderResult.Errors);

        var order = await repository.AddAsync(createOrderResult.Value);

        return Result.Ok(MapOrderToDto(order));
    }
}