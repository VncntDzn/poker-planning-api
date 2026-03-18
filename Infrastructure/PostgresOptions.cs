using System.ComponentModel.DataAnnotations;

namespace poker_planning_api.Infrastructure;


public sealed class PostgresOptions
{
    public const string SectionName = "Postgres";

    [Required]
    public string ConnectionString { get; init; } = string.Empty;
}