using Retailer.Application.DTOs;
using Retailer.Application.Mappers;
using Retailer.Common;
using Retailer.Core.Products;

namespace Retailer.Application.UseCases.ListProducts;

public class ListProductsHandler(IProductsRepository productsRepository) : IQueryHandler<IEnumerable<ProductDTO>>
{
    public async Task<Result<IEnumerable<ProductDTO>>> Query()
    {
        var products = await productsRepository.GetAllAsync();
        return ProductsMapper.MapProductToDto(products);
    }
}
