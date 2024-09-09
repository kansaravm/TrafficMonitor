using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;
using TrafficMonitor.UnitTests.Services;

namespace TrafficMonitor.Infrastructure.Services.Tests
{
    public class CacheServiceTests
    {
        private readonly InMemoryCache _cache;
        private readonly CacheService _cacheService;

        public CacheServiceTests()
        {
            _cache = new InMemoryCache();
            _cacheService = new CacheService(_cache);
        }
        [Fact]
        public async Task GetAsyncShouldReturnCachedValueWhenCacheIsEmpty()
        {
            string key = "products";    
            
            var result = await _cacheService.GetAsync<Product>(key);
            
            Assert.Null(result);
           
        }

        [Fact]
        public async Task GetAsyncShouldReturnCachedValueWhenCacheIsNotEmpty()
        {          
            string key = "products";
            var expected = new Product { Name = "Product1" };
            string serializedValue = JsonSerializer.Serialize(expected);
            byte[] serializedValueBytes = Encoding.UTF8.GetBytes(serializedValue);

            // Store the serialized JSON string in the cache
            await _cache.SetAsync(key, serializedValueBytes, new DistributedCacheEntryOptions());
            
            var result = await _cacheService.GetAsync<Product>(key);
            
            Assert.NotNull(result);
            Assert.Equal(expected.Name, result!.Name);
        }

        [Fact]
        public async Task SetAsyncShouldStoreValueInCache()
        {
            
            string key = "products";
            var product = new Product { Name = "Product2" };
            string serializedValue = JsonSerializer.Serialize(product);
            byte[] serializedValueBytes = Encoding.UTF8.GetBytes(serializedValue);
            
            await _cacheService.SetAsync(key, product);
            
            byte[] cachedValueBytes = await _cache.GetAsync(key);
            string cachedValue = Encoding.UTF8.GetString(cachedValueBytes);
            
            Assert.NotNull(cachedValue);
            Assert.Equal(serializedValue, cachedValue);
        }

        private class Product
        {
            public string Name { get; set; } = string.Empty;
        }
    }
}