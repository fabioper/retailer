using Retailer.Application.DTOs;
using Retailer.Application.Mappers;
using Retailer.Common;
using Retailer.Core.DiscountPolicies;
using Retailer.Core.Products;
using Retailer.Core.Sales;

namespace Retailer.Application.UseCases.AddItemToSale;

public class AddItemToSaleHandler(
    ISalesRepository salesRepository,
    IProductsRepository productsRepository,
    IDiscountPoliciesRepository discountPoliciesRepository)
    : IUseCase<AddItemToSaleCommand, SaleDTO>
{
    public async Task<Result<SaleDTO>> Execute(AddItemToSaleCommand command)
    {
        var sale = await salesRepository.GetByIdAsync(command.SaleId);
        if (sale is null)
            return Result.Fail(CommonErrors.EntityNotFound(nameof(Sale), command.SaleId));

        var product = await productsRepository.GetByIdAsync(command.ProductId);
        if (product is null)
            return Result.Fail(CommonErrors.EntityNotFound(nameof(Product), command.ProductId));

        var discountPolicies = await discountPoliciesRepository.GetAvailableDiscounts();

        var addItemResult = sale.AddItem(product.Id, product.Price, command.Quantity);
        if (addItemResult.IsFailed)
            return Result.Fail(addItemResult.Errors);

        sale.ApplyDiscountPolicies(discountPolicies);

        await salesRepository.SaveChangesAsync();

        return Result.Ok(SaleMapper.MapSaleToDto(sale));
    }
}
