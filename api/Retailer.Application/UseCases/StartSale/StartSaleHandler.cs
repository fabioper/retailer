using Retailer.Application.DTOs;
using Retailer.Common;
using Retailer.Core.Sales;
using static Retailer.Application.Mappers.SaleMapper;

namespace Retailer.Application.UseCases.StartSale;

public class StartSaleHandler(ISalesRepository repository) : IUseCase<SaleDTO>
{
    public async Task<Result<SaleDTO>> Execute()
    {
        var startSaleResult = Sale.Start();

        if (startSaleResult.IsFailed)
            return Result.Fail<SaleDTO>(startSaleResult.Errors);

        var sale = await repository.AddAsync(startSaleResult.Value);

        await repository.SaveChangesAsync();

        return Result.Ok(MapSaleToDto(sale));
    }
}
