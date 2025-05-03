using Retailer.Application.UseCases.GetSale;
using Retailer.Application.UseCases.StartSale;

namespace Retailer.Application;

public static class ApplicationServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<StartSaleHandler>();
        services.AddScoped<GetSaleHandler>();
    }
}