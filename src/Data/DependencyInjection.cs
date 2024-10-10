using Microsoft.Extensions.DependencyInjection;
using RiddleSolver.Core.Contracts;
using RiddleSolver.Data.Services;

namespace RiddleSolver.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddTransient<ICacheService, InMemoryCacheService>();
        return services;
    }
}