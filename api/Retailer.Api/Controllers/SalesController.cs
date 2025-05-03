using Retailer.Application.DTOs;
using Retailer.Application.UseCases.CreateSale;
using Retailer.Application.UseCases.GetSale;

namespace Retailer.Api.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController : ControllerBase
{
    [HttpGet("{saleId:guid}")]
    public async Task<ActionResult<SaleDTO>> GetSale(Guid saleId, GetSaleHandler handler)
    {
        var result = await handler.Execute(saleId);
        return result.ToActionResult();
    }

    [HttpPost]
    public async Task<ActionResult<SaleDTO>> CreateSale(CreateSaleHandler handler)
    {
        var result = await handler.Execute();
        return result.ToActionResult();
    }
}