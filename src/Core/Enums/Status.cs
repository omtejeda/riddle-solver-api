namespace RiddleSolver.Core.Enums;

/// <summary>
/// Enumeration representing the possible statuses for an operation or request result.
/// </summary>
public enum Status
{
    /// <summary>
    /// Indicates the operation was successful.
    /// </summary>
    Success,

    /// <summary>
    /// Indicates there was a validation error in the request.
    /// </summary>
    ValidationError,

    /// <summary>
    /// Indicates the request was understood but cannot be processed.
    /// </summary>
    Unprocessable,

    /// <summary>
    /// Indicates an unexpected error occurred during the operation.
    /// </summary>
    UnexpectedError
}