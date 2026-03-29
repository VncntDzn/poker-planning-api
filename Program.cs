using poker_planning_api.Infrastructure;
using Scalar.AspNetCore;
using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();
    builder.Services.AddInfrastructure(builder.Configuration);

// serilog config.
    builder.Host.UseSerilog((context, services, config) => config.ReadFrom.Configuration(context.Configuration).ReadFrom
        .Services(services).Enrich.FromLogContext());

    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    app.UseSerilogRequestLogging(options =>
    {
        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
        {
            diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
            diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
            diagnosticContext.Set("TraceIdentifier", httpContext.TraceIdentifier);
        };
    });


    app.UseHttpsRedirection();
    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Program terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}