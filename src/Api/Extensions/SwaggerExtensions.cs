using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using RiddleSolver.Api.Constants;

namespace RiddleSolver.Api.Extensions;

/// <summary>
/// Extension methods for setting up Swagger in the API.
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    /// Adds Swagger services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to add Swagger to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApiSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc(nameof(ApiVersions.v1), new OpenApiInfo
            {
                Title = "Riddle Solver REST API",
                Contact = new OpenApiContact 
                { 
                    Name = "omtejeda",
                    Url = new("https://github.com/omtejeda")
                }
            });
        });
        return services;
    }

    /// <summary>
    /// Configures the Swagger UI in the specified <see cref="IApplicationBuilder"/>.
    /// </summary>
    /// <param name="app">The application builder to configure Swagger UI for.</param>
    /// <returns>The updated application builder.</returns>
    public static IApplicationBuilder UseApiSwagger(this IApplicationBuilder app)
    {
        var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = string.Empty;
            foreach (var groupName in provider.ApiVersionDescriptions.Select(x => x.GroupName))
            {
                c.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant());
            }
        });
        
        return app;
    }
}