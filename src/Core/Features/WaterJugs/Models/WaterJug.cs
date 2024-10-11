namespace RiddleSolver.Core.Features.WaterJugs.Models;

/// <summary>
/// Represents the configuration for the Water Jug problem, including the capacities of the jugs and the desired amount of water.
/// </summary>
/// <param name="CapacityX">The capacity of the first jug.</param>
/// <param name="CapacityY">The capacity of the second jug.</param>
/// <param name="AmountWanted">The desired amount of water to measure.</param>
public record struct WaterJug(int CapacityX, int CapacityY, int AmountWanted);