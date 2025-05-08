using Retailer.Application.DTOs;
using Retailer.Core.Products;

namespace Retailer.Application.Mappers;

public static class ProductsMapper
{
    public static ProductDTO MapProductToDto(Product product)
        => new(product.Id, product.Name, product.Price);

    public static Result<IEnumerable<ProductDTO>> MapProductToDto(IEnumerable<Product> products)
        => products.Select(MapProductToDto).ToList();
}
