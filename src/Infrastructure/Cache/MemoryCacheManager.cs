using Application.Contracts.Cache;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    public class MemoryCacheManager : ICacheManager
    {
        private IMemoryCache _cache;
        public MemoryCacheManager(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void Add(string key, object data, int duration)
        {
            _cache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public bool IsAdd(string key)
        {
            var data = _cache.TryGetValue(key, out _);
            return data;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }


    }
}
