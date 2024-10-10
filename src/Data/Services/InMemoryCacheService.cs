using RiddleSolver.Core.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace RiddleSolver.Data.Services;

internal class InMemoryCacheService(IMemoryCache memoryCache, ILogger<InMemoryCacheService> logger) : ICacheService
{
    private readonly IMemoryCache _cache = memoryCache;
    private readonly ILogger _logger = logger;
    private static readonly MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
        SlidingExpiration = TimeSpan.FromMinutes(30)
    };

    public T Get<T>(string key)
    {
        _logger.LogInformation("Getting cache for key {Key}", key);
        return _cache.Get<T>(key)!;
    }

    public void Set<T>(string key, T data)
    {
        _logger.LogInformation("Setting cache for key {Key}", key);
        _cache.Set(key, data, cacheEntryOptions);
    }
}