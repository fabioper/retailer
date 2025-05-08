using Retailer.Api.Models;
using Retailer.Application.DTOs;
using Retailer.Application.UseCases.CreateProduct;
using Retailer.Application.UseCases.ListProducts;

namespace Retailer.Api.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateProduct(
        [FromBody] CreateProductRequest request, [FromServices] CreateProductHandler handler)
    {
        var result = await handler.Execute(new CreateProductCommand(request.Name, request.Price));
        return result.ToActionResult();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts([FromServices] ListProductsHandler handler)
    {
        var result = await handler.Query();
        return result.ToActionResult();
    }
}
