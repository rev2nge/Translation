namespace Translation.Application.Interfaces
{
    public interface ICacheService
    {
        Task<string?> GetCachedValueAsync(string key);
        Task SetCachedValueAsync(string key, string value);
        int CacheSize { get; }
    }
}