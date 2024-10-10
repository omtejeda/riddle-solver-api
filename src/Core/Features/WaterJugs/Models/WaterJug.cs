namespace RiddleSolver.Core.Features.WaterJugs.Models;

/// <summary>
/// Represents the configuration for the Water Jug problem, including the capacities of the jugs and the desired amount of water.
/// </summary>
public record struct WaterJug(int CapacityX, int CapacityY, int AmountWanted);