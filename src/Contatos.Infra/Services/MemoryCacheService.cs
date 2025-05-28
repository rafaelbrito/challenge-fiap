using Microsoft.Extensions.Caching.Memory;
using Contatos.Core.Interfaces;
namespace Contatos.Infra.Services
{
    public class MemoryCacheService : IServiceCache
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Set<T>(string key, T value, TimeSpan expirationTime)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expirationTime
            };
            _memoryCache.Set(key, value, options);
        }

        public bool TryGetValue<T>(string key, out T value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
