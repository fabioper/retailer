using Retailer.Application.DTOs;
using Retailer.Common;
using Retailer.Core.Sales;
using static Retailer.Application.Mappers.SaleMapper;

namespace Retailer.Application.UseCases.CreateSale;

public class CreateSaleHandler(ISalesRepository repository) : IUseCase<SaleDTO>
{
    public async Task<Result<SaleDTO>> Execute()
    {
        var createSaleResult = Sale.Create();

        if (createSaleResult.IsFailed)
            return Result.Fail<SaleDTO>(createSaleResult.Errors);

        var sale = await repository.AddAsync(createSaleResult.Value);

        return Result.Ok(MapSaleToDto(sale));
    }
}