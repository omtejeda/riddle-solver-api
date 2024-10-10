namespace RiddleSolver.Core.Features.WaterJugs.Models;

/// <summary>
/// Represents the state of two water jugs at a specific step in the process of solving the Water Jug problem.
/// </summary>
/// <param name="StepDescription">A brief description of the action or step taken to reach this state.</param>
/// <param name="Jug1">The current amount of water in the first jug.</param>
/// <param name="Jug2">The current amount of water in the second jug.</param>
public record JugState(string StepDescription, int Jug1, int Jug2);