using Retailer.Application.DTOs;
using Retailer.Core.Sales;

namespace Retailer.Application.Mappers;

public static class SaleMapper
{
    public static SaleDTO MapSaleToDto(Sale sale) => new(
        sale.Id,
        sale.Items.Select(MapSaleItemToDto).ToList(),
        sale.Total,
        sale.Status.ToString());

    private static SaleItemDTO MapSaleItemToDto(SaleItem item) => new(item.Id, item.Price, item.Quantity);
}