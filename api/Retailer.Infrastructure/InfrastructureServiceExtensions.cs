using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Retailer.Core.DiscountPolicies;
using Retailer.Core.Sales;
using Retailer.Infrastructure.Persistence;
using Retailer.Infrastructure.Persistence.Repositories;

namespace Retailer.Infrastructure;

public static class InfrastructureServiceExtensions
{
    private const string DbConnectionStringKey = "Database";

    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseNpgsql(configuration.GetConnectionString(DbConnectionStringKey)));

        services.AddScoped<ISalesRepository, SalesRepository>();
        services.AddScoped<IDiscountPoliciesRepository, DiscountPoliciesRepository>();
    }
}
