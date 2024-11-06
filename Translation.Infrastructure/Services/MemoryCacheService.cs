using Translation.Application.Interfaces;

namespace Translation.Infrastructure.Services
{
    public class MemoryCacheService : ICacheService
    {
        private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();

        public Task<string?> GetCachedValueAsync(string key)
        {
            _cache.TryGetValue(key, out var value);
            return Task.FromResult(value);
        }

        public Task SetCachedValueAsync(string key, string value)
        {
            _cache[key] = value;
            return Task.CompletedTask;
        }

        public int CacheSize => _cache.Count;
    }
}