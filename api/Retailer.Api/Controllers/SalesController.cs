using Retailer.Application.DTOs;
using Retailer.Application.UseCases.GetSale;
using Retailer.Application.UseCases.StartSale;

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
    public async Task<ActionResult<SaleDTO>> StartSale(StartSaleHandler handler)
    {
        var result = await handler.Execute();
        return result.ToActionResult();
    }
}