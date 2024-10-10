using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RiddleSolver.Core.Features.WaterJugs.Decorators;
using RiddleSolver.Core.Features.WaterJugs.Services;
using RiddleSolver.Core.Contracts;
using RiddleSolver.Core.Features.WaterJugs.UseCases.Solve;

namespace RiddleSolver.Core.Features.WaterJugs;

public static class DependencyInjection
{
    public static IServiceCollection AddWaterJugs(this IServiceCollection services)
    {
        services.AddTransient<IWaterJugService, WaterJugService>();
        services.Decorate<IWaterJugService, WaterJugServiceCacheDecorator>();
        services.AddScoped<IValidator<SolveWaterJugCommand>, SolveWaterJugValidator>();
        return services;
    }
}