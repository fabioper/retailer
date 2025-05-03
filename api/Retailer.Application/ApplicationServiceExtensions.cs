using Retailer.Application.UseCases.CreateSale;
using Retailer.Application.UseCases.GetSale;

namespace Retailer.Application;

public static class ApplicationServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CreateSaleHandler>();
        services.AddScoped<GetSaleHandler>();
    }
}