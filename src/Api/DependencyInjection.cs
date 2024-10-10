using RiddleSolver.Api.Constants;
using RiddleSolver.Api.Extensions;
using RiddleSolver.Api.Middlewares;

namespace RiddleSolver.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddVersioning();
        services.AddEndpointsApiExplorer();
        services.AddRouting(o => o.LowercaseUrls = true);
        services.AddControllers(o => o.UseGeneralRoutePrefix(Routes.GlobalPrefix));
        services.AddApiSwagger();
        return services;
    }
}