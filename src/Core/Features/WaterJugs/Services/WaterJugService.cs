using System.Numerics;
using RiddleSolver.Core.Models;
using RiddleSolver.Core.Features.WaterJugs.Models;
using RiddleSolver.Core.Enums;
using RiddleSolver.Core.Contracts;
using RiddleSolver.Core.Features.WaterJugs.DTOs;
using RiddleSolver.Core.Features.WaterJugs.Constants;

namespace RiddleSolver.Core.Features.WaterJugs.Services;

internal class WaterJugService : IWaterJugService
{
    private const string SolvedMessage = "Solved";
    
    public bool CanBeMeasured(WaterJug waterJug)
    {
        bool IsLessThanOrEqualToTotalCapacity = waterJug.AmountWanted <= waterJug.CapacityX + waterJug.CapacityY;
        bool IsPossibleToMeasure = waterJug.AmountWanted % BigInteger.GreatestCommonDivisor(waterJug.CapacityX, waterJug.CapacityY) == 0;

        return IsLessThanOrEqualToTotalCapacity && IsPossibleToMeasure;
    }

    public Result<WaterJugResponseDto> Solve(WaterJug waterJug)
    {
        if (!CanBeMeasured(waterJug))
        {
            return NoSolutionResult();
        }

        bool[,] visitedStates = new bool[waterJug.CapacityX + 1, waterJug.CapacityY + 1];
        var queue = new Queue<(int, int)>();
        var path = new Dictionary<(int, int), List<StepTaken>>();

        queue.Enqueue((0, 0));
        visitedStates[0, 0] = true;
        path[(0, 0)] = [];

        // BFS loop
        while (queue.Count > 0)
        {
            var (currentJug1, currentJug2) = queue.Dequeue();

            bool eitherJugHasAmountWanted = currentJug1 == waterJug.AmountWanted || currentJug2 == waterJug.AmountWanted;
            if (eitherJugHasAmountWanted)
            {
                var solutionSteps = new List<StepTaken>(path[(currentJug1, currentJug2)]);
                MarkLastStepAsSolved(solutionSteps);
                
                return  Result<WaterJugResponseDto>.Successful(SolvedMessage, new(solutionSteps));
            }

            foreach (var jugState in GetJugStates(currentJug1, currentJug2, waterJug.CapacityX, waterJug.CapacityY))
            {
                if (!visitedStates[jugState.Jug1, jugState.Jug2])
                {
                    visitedStates[jugState.Jug1, jugState.Jug2] = true;
                    queue.Enqueue((jugState.Jug1, jugState.Jug2));
                    RecordStepTaken(path, jugState, currentJug1, currentJug2);
                }
            }
        }
        return NoSolutionResult();
    }

    private static Result<WaterJugResponseDto> NoSolutionResult()
        => Result<WaterJugResponseDto>.Failed(Status.Unprocessable, "No Solution");

    private static void RecordStepTaken(Dictionary<(int, int), List<StepTaken>> path, JugState jugState, int currentJug1, int currentJug2)
    {
        var stepNumber = path[(currentJug1, currentJug2)].Count + 1;
        
        var currentPath = new List<StepTaken>(path[(currentJug1, currentJug2)])
        {
            new(stepNumber, jugState.Jug1, jugState.Jug2, jugState.StepDescription)
        };

        path[(jugState.Jug1, jugState.Jug2)] = currentPath;
    }

    private static IEnumerable<JugState> GetJugStates(int currentJug1, int currentJug2, int capacityX, int capacityY)
    {
        const int emptyJugValue = 0;

        yield return new(StepDescription.FillJug1, capacityX, currentJug2);
        yield return new(StepDescription.FillJug2, currentJug1, capacityY);
        yield return new(StepDescription.EmptyJug1, emptyJugValue, currentJug2);
        yield return new(StepDescription.EmptyJug2, currentJug1, emptyJugValue);
        yield return new(StepDescription.PourJug2ToJug1, Math.Min(currentJug1 + currentJug2, capacityX), currentJug2 - (Math.Min(currentJug1 + currentJug2, capacityX) - currentJug1));
        yield return new(StepDescription.PourJug1ToJug2, currentJug1 - (Math.Min(currentJug1 + currentJug2, capacityY) - currentJug2), Math.Min(currentJug1 + currentJug2, capacityY));
    }

    private static void MarkLastStepAsSolved(List<StepTaken> solutionSteps)
    {
        if (solutionSteps.Count == 0)
            return;

        var lastStep = solutionSteps.Last();

        solutionSteps[^1] = new StepTaken(
            lastStep.Step,
            lastStep.BucketX,
            lastStep.BucketY,
            $"{lastStep.Action}. {SolvedMessage.ToUpper()}");
    }
}
