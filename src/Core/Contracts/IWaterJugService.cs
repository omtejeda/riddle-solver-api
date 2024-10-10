using RiddleSolver.Core.Models;
using RiddleSolver.Core.Features.WaterJugs.Models;
using RiddleSolver.Core.Features.WaterJugs.DTOs;

namespace RiddleSolver.Core.Contracts;

/// <summary>
/// Service interface for operations related to the Water Jug problem.
/// </summary>
public interface IWaterJugService
{
    /// <summary>
    /// Determines if the desired quantity of water can be measured using the given jugs.
    /// </summary>
    /// <param name="waterJug">The water jug configuration, including capacities of two jugs and the target amount.</param>
    /// <returns>A boolean indicating whether the target amount can be measured.</returns>
    bool CanBeMeasured(WaterJug waterJug);

    /// <summary>
    /// Solves the Water Jug problem and provides the steps to reach the target amount.
    /// </summary>
    /// <param name="waterJug">The water jug configuration, including capacities of two jugs and the target amount.</param>
    /// <returns>A result containing the solution steps wrapped in <see cref="WaterJugResponseDto"/> if solvable, or an error message.</returns>
    Result<WaterJugResponseDto> Solve(WaterJug waterJug);
}