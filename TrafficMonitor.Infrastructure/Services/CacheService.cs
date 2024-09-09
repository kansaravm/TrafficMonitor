using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Concurrent;
using System.Text.Json;
using TrafficMonitor.Infrastructure.Abstractions;

namespace TrafficMonitor.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private static ConcurrentDictionary<string, bool> CacheKeys = new();
        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        private readonly IDistributedCache _distributedCache;
        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            string? cachedValue = await _distributedCache.GetStringAsync(key, cancellationToken);
            if (cachedValue is null) return null;
            T? value = JsonSerializer.Deserialize<T>(cachedValue);
            return value;
        }
        public async Task<T> GetAsync<T>(string key, Func<Task<T>> factory, CancellationToken cancellationToken = default) where T : class
        {
            T? cachedValue = await GetAsync<T>(key, cancellationToken);
            if (cachedValue is not null) return cachedValue;
            cachedValue = await factory();
            await SetAsync(key, cachedValue, cancellationToken);
            return cachedValue;
        }
        public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
        {
            string cacheValue = JsonSerializer.Serialize(value);
            await _distributedCache.SetStringAsync(key, cacheValue, cancellationToken);
            CacheKeys.TryAdd(key, false);
        }     


    }
}
