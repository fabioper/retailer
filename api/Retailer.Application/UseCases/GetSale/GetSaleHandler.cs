using Retailer.Application.DTOs;
using Retailer.Common;
using Retailer.Core.Sales;
using static Retailer.Application.Mappers.SaleMapper;

namespace Retailer.Application.UseCases.GetSale;

public class GetSaleHandler(ISalesRepository repository) : IQueryHandler<Guid, SaleDTO>
{
    public async Task<Result<SaleDTO>> Execute(Guid saleId)
    {
        var sale = await repository.GetByIdAsync(saleId);

        return sale is null
            ? Result.Fail<SaleDTO>(CommonErrors.EntityNotFound(nameof(Sale), saleId))
            : Result.Ok(MapSaleToDto(sale));
    }
}