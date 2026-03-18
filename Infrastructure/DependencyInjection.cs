using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace poker_planning_api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddOptions<PostgresOptions>()
            .Bind(configuration.GetSection(PostgresOptions.SectionName))
            .ValidateDataAnnotations()
            .Validate(
                x => !string.IsNullOrWhiteSpace(x.ConnectionString),
                "Postgres connection string is required.")
            .ValidateOnStart();
        
        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            var postgresOptions = sp
                .GetRequiredService<IOptions<PostgresOptions>>()
                .Value;

            options.UseNpgsql(postgresOptions.ConnectionString);
        });


        return services;
    }
}

public sealed class PostgresOptions
{
    public const string SectionName = "Postgres";

    [Required]
    public string ConnectionString { get; init; } = string.Empty;
}