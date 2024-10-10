namespace RiddleSolver.Core.Contracts;

/// <summary>
/// Interface that defines caching operations for storing and retrieving data.
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// Retrieves an item from the cache based on the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the object to retrieve from the cache.</typeparam>
    /// <param name="key">The unique key to identify the cached item.</param>
    /// <returns>The cached item if found, otherwise the default value of type <typeparamref name="T"/>.</returns>
    T Get<T>(string key);

    /// <summary>
    /// Adds or updates an item in the cache with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the object to store in the cache.</typeparam>
    /// <param name="key">The unique key to identify the cached item.</param>
    /// <param name="data">The data to cache.</param>
    void Set<T>(string key, T data);
}