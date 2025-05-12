using Retailer.Application.UseCases.AddItemToSale;
using Retailer.Application.UseCases.CompleteSale;
using Retailer.Application.UseCases.CreateProduct;
using Retailer.Application.UseCases.GetSale;
using Retailer.Application.UseCases.ListProducts;
using Retailer.Application.UseCases.StartSale;

namespace Retailer.Application;

public static class ApplicationServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<StartSaleHandler>();
        services.AddScoped<GetSaleHandler>();
        services.AddScoped<CompleteSaleHandler>();
        services.AddScoped<ListProductsHandler>();
        services.AddScoped<CreateProductHandler>();
        services.AddScoped<AddItemToSaleHandler>();
    }
}
