using PontoDeVenda.Application.DTOs;
using PontoDeVenda.Application.UseCases.CreateOrder;
using PontoDeVenda.Application.UseCases.GetOrder;

namespace PontoDeVenda.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    [HttpGet("{orderId:guid}")]
    public async Task<ActionResult<OrderDTO>> GetOrder(Guid orderId, GetOrderHandler handler)
    {
        var result = await handler.Execute(orderId);
        return result.ToActionResult();
    }

    [HttpPost]
    public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO orderDto, CreateOrderHandler handler)
    {
        var result = await handler.Execute();
        return result.ToActionResult();
    }
}