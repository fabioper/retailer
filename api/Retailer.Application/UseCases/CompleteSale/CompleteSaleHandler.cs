using Retailer.Application.DTOs;
using Retailer.Application.Mappers;
using Retailer.Common;
using Retailer.Core.DiscountPolicies;
using Retailer.Core.Sales;

namespace Retailer.Application.UseCases.CompleteSale;

public class CompleteSaleHandler(
    IDiscountPoliciesRepository discountPoliciesRepository,
    ISalesRepository salesRepository) : IUseCase<Guid, SaleDTO>
{
    public async Task<Result<SaleDTO>> Execute(Guid saleId)
    {
        var sale = await salesRepository.GetByIdAsync(saleId);
        if (sale is null)
            return Result.Fail(CommonErrors.EntityNotFound(nameof(Sale), saleId));

        var availableDiscounts = await discountPoliciesRepository.GetAvailableDiscounts();
        sale.ApplyDiscountPolicies(availableDiscounts.Where(c => c.IsApplicable(sale)));

        var completeSaleResult = sale.Complete();

        if (completeSaleResult.IsFailed)
            return Result.Fail(completeSaleResult.Errors);

        await salesRepository.SaveChangesAsync();
        return Result.Ok(SaleMapper.MapSaleToDto(sale));
    }
}
