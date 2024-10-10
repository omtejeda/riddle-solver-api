namespace RiddleSolver.Core.Features.WaterJugs.DTOs;

/// <summary>
/// Represents the response containing the solution steps for the Water Jug problem.
/// </summary>
/// <param name="Solution">A collection of steps taken to achieve the desired outcome.</param>
public sealed record WaterJugResponseDto(ICollection<StepTaken> Solution);

/// <summary>
/// Represents a single step taken in solving the Water Jug problem.
/// </summary>
/// <param name="Step">The step number in the solution sequence.</param>
/// <param name="BucketX">The amount of water in bucket X after the step.</param>
/// <param name="BucketY">The amount of water in bucket Y after the step.</param>
/// <param name="Action">The action performed in this step.</param>
public sealed record StepTaken(int Step, int BucketX, int BucketY, string Action);