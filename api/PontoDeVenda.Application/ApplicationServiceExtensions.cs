using PontoDeVenda.Application.UseCases.CreateOrder;
using PontoDeVenda.Application.UseCases.GetOrder;

namespace PontoDeVenda.Application;

public static class ApplicationServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CreateOrderHandler>();
        services.AddScoped<GetOrderHandler>();
    }
}