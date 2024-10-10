using RiddleSolver.Core.Enums;

namespace RiddleSolver.Core.Models;

/// <summary>
/// Represents the result of an operation, including success status, message, and optional data.
/// </summary>
/// <typeparam name="T">The type of the data included in the result.</typeparam>
public sealed record Result<T> where T : class
{
    public bool Success { get; private set; }
    public string Status { get; private set; } = string.Empty;
    public string Message { get; private set; } = string.Empty;
    public T? Data { get; private set; }

    /// <summary>
    /// Creates a successful result with the specified message and data.
    /// </summary>
    /// <param name="message">A message describing the success.</param>
    /// <param name="data">The data returned with the result.</param>
    /// <returns>A successful <see cref="Result{T}"/> instance.</returns>
    public static Result<T> Successful(string message, T? data)
        => new() { Success = true, Status = Enums.Status.Success.ToString(), Message = message, Data = data };
    
    /// <summary>
    /// Creates a failed result with the specified status and message.
    /// </summary>
    /// <param name="status">The status indicating the reason for failure.</param>
    /// <param name="message">A message describing the failure.</param>
    /// <returns>A failed <see cref="Result{T}"/> instance.</returns>
    public static Result<T> Failed(Status status, string message)
        => new() { Success = false, Status = status.ToString(), Message = message };
}