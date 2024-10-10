using RiddleSolver.Core.Features.WaterJugs;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RiddleSolver.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddWaterJugs();
        return services;
    }
}