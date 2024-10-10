using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using RiddleSolver.Api.Constants;

namespace RiddleSolver.Api.Extensions;

public static class SwaggerExtensions
{
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