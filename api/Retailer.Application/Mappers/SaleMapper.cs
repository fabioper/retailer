using Retailer.Application.DTOs;
using Retailer.Core.Sales;

namespace Retailer.Application.Mappers;

public static class SaleMapper
{
    public static SaleDTO MapSaleToDto(Sale sale)
    {
        return new SaleDTO(
            Id: sale.Id,
            Items: sale.Items.Select(MapSaleItemToDto).ToList(),
            Total: sale.Total,
            Subtotal: sale.Subtotal,
            TotalDiscounts: sale.TotalDiscounts,
            AppliedDiscounts: sale.AppliedDiscounts.Select(MapDiscountToDto).ToList(),
            Status: sale.Status.ToString());
    }

    private static AppliedDiscountDTO MapDiscountToDto(AppliedDiscount d) => new(d.PolicyId, d.Total);

    private static SaleItemDTO MapSaleItemToDto(SaleItem item) => new(item.Id, item.Price, item.Quantity);
}