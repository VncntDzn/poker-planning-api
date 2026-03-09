using Microsoft.EntityFrameworkCore;

namespace poker_planning_api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("AppDbConnection")));


        return services;
    }
}