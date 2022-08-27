using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection"); 
        services.AddDbContext<ApplicationDbContext>(options => 
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), 
        b => b.MigrationsAssembly(typeof (ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}