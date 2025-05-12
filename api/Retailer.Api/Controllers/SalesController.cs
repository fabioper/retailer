using Retailer.Api.Models;
using Retailer.Application.DTOs;
using Retailer.Application.UseCases.AddItemToSale;
using Retailer.Application.UseCases.GetSale;
using Retailer.Application.UseCases.StartSale;

namespace Retailer.Api.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController : ControllerBase
{
    [HttpGet("{saleId:guid}")]
    public async Task<ActionResult<SaleDTO>> GetSale(Guid saleId, [FromServices] GetSaleHandler handler)
    {
        var result = await handler.Execute(saleId);
        return result.ToActionResult();
    }

    [HttpPost]
    public async Task<ActionResult<SaleDTO>> StartSale([FromServices] StartSaleHandler handler)
    {
        var result = await handler.Execute();
        return result.ToActionResult();
    }

    [HttpPost("{saleId:guid}/items")]
    public async Task<ActionResult<SaleDTO>> AddItemToSale(Guid saleId,
        [FromBody] AddItemToSaleRequest request, [FromServices] AddItemToSaleHandler handler)
    {
        var result = await handler.Execute(new AddItemToSaleCommand(saleId, request.ProductId, request.Quantity));
        return result.ToActionResult();
    }
}
