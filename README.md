# poker-planning-api

## Local secrets

This project loads `Postgres:ConnectionString` from ASP.NET Core configuration.
In local development, store it with User Secrets instead of committing it to `appsettings.json`.

```bash
dotnet user-secrets set "Postgres:ConnectionString" "Host=localhost;Port=5436;Database=poker-planning-db;Username=postgres;Password=your-password"
dotnet user-secrets list
```

`WebApplication.CreateBuilder(args)` loads User Secrets automatically when `ASPNETCORE_ENVIRONMENT=Development`.
