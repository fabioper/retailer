using Retailer.Application.DTOs;
using Retailer.Application.Mappers;
using Retailer.Common;
using Retailer.Core.Products;

namespace Retailer.Application.UseCases.CreateProduct;

public class CreateProductHandler(IProductsRepository productsRepository) : IUseCase<CreateProductCommand, ProductDTO>
{
    public async Task<Result<ProductDTO>> Execute(CreateProductCommand command)
    {
        var createProductResult = Product.Create(command.Name, command.Price);

        if (createProductResult.IsFailed)
            return Result.Fail(createProductResult.Errors);

        var createdProduct = await productsRepository.AddProductAsync(createProductResult.Value);
        await productsRepository.SaveChangesAsync();

        return Result.Ok(ProductsMapper.MapProductToDto(createdProduct));
    }
}
