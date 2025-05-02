using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PontoDeVenda.Infrastructure.Persistence;

namespace PontoDeVenda.Infrastructure;

public static class InfrastructureServiceExtensions
{
    private const string DbConnectionStringKey = "Database";

    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseNpgsql(configuration.GetConnectionString(DbConnectionStringKey)));
    }
}