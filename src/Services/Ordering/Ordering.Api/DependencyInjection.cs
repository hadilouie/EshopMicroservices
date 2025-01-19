﻿using BuildingBlocks.Exceptions.Handler;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Ordering.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.

        services.AddCarter();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("Database")!);

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        // Configure the HTTP request pipeline
        app.UseExceptionHandler(options => { });
        app.UseHealthChecks("/health",
            new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

        app.MapCarter();

        return app;
    }
}
