﻿namespace TrafficMonitor.Infrastructure.Abstractions
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class;        
        Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class;        
    }
}
