namespace RiddleSolver.Core.Features.WaterJugs.Constants;

/// <summary>
/// Provides descriptions of the steps taken in the Water Jug problem.
/// </summary>
public static class StepDescription
{
    public const string FillJug1 = "Fill bucket x";
    public const string FillJug2 = "Fill bucket y";
    public const string EmptyJug1 = "Empty bucket x";
    public const string EmptyJug2 = "Empty bucket y";
    public const string PourJug2ToJug1 = "Transfer from bucket y to bucket x";
    public const string PourJug1ToJug2 = "Transfer from bucket x to bucket y";
}