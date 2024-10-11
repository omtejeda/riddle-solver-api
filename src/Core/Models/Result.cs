using RiddleSolver.Core.Enums;

namespace RiddleSolver.Core.Models;

/// <summary>
/// Represents the result of an operation, including success status, message, and optional data.
/// </summary>
/// <typeparam name="T">The type of the data included in the result.</typeparam>
public sealed record Result<T> where T : class
{
    /// <summary>
    /// Indicates whether the operation was successful.
    /// </summary>
    public bool Success { get; private set; }

    /// <summary>
    /// The status of the operation, indicating success or failure reason.
    /// </summary>
    public string Status { get; private set; } = string.Empty;

    /// <summary>
    /// A message providing additional information about the result.
    /// </summary>
    public string Message { get; private set; } = string.Empty;

    /// <summary>
    /// Optional data returned with the result.
    /// </summary>
    public T? Data { get; private set; }

    /// <summary>
    /// Creates a successful result with the specified message and data.
    /// </summary>
    public static Result<T> Successful(string message, T? data)
    {
        return new()
        {
            Success = true,
            Status = Enums.Status.Success.ToString(),
            Message = message,
            Data = data
        };
    }
    
    /// <summary>
    /// Creates a failed result with the specified status and message.
    /// </summary>
    public static Result<T> Failed(Status status, string message)
    {
        return new()
        {
            Success = false,
            Status = status.ToString(),
            Message = message
        };
    }
}