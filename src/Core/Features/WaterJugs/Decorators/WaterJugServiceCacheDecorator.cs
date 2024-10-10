using RiddleSolver.Core.Models;
using RiddleSolver.Core.Features.WaterJugs.Models;
using RiddleSolver.Core.Contracts;
using RiddleSolver.Core.Features.WaterJugs.DTOs;
using Microsoft.Extensions.Logging;

namespace RiddleSolver.Core.Features.WaterJugs.Decorators;

internal class WaterJugServiceCacheDecorator(
    IWaterJugService waterJugService,
    ICacheService cacheService,
    ILogger<WaterJugServiceCacheDecorator> logger) : IWaterJugService
{
    private readonly IWaterJugService _waterJugService = waterJugService;
    private readonly ICacheService _cacheService = cacheService;
    private readonly ILogger _logger = logger;

    public bool CanBeMeasured(WaterJug waterJug)
    {
        return _waterJugService.CanBeMeasured(waterJug);
    }

    public Result<WaterJugResponseDto> Solve(WaterJug waterJug)
    {
        var solveCached = GetSolveResultFromCache(waterJug);

        if (solveCached is not null)
        {
            _logger.LogInformation("Returning from cache Solve result for values {Values}", GetWaterJugKey(waterJug));
            return solveCached;
        }

        _logger.LogInformation("Computing Solve algorithm for values {Values}", GetWaterJugKey(waterJug));
        var result = _waterJugService.Solve(waterJug);

        SetCache(waterJug, result);
        return result;
    }

    #region Helpers
    private Result<WaterJugResponseDto> GetSolveResultFromCache(WaterJug waterJug)
    {
        string waterJugKey = GetWaterJugKey(waterJug);
        return _cacheService.Get<Result<WaterJugResponseDto>>(waterJugKey);
    }
    
    private void SetCache(WaterJug waterJug, Result<WaterJugResponseDto> waterJugResponse)
    {
        string waterJugKey = GetWaterJugKey(waterJug);
        _cacheService.Set<Result<WaterJugResponseDto>>(waterJugKey, waterJugResponse);
    }

    private static string GetWaterJugKey(WaterJug waterJug) 
        => $"{waterJug.CapacityX}-{waterJug.CapacityY}-{waterJug.AmountWanted}";
    #endregion
}