using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace EpicOS.Helpers
{
    public class CacheNinja
    {
        public ObjectCache cache = MemoryCache.Default;
        public DateTimeOffset cacheExpiry = new DateTimeOffset(DateTime.UtcNow.AddDays(1));

        public bool ClearCache(string key)
        {
            bool status = false;
            if (cache[key] == null)
            {
                status = true;
            }
            else
            {
                try
                {
                    cache.Remove(key);
                    status = true;
                }
                catch
                {
                }
            }
            return status;
        }

        public bool ClearAllCache()
        {
            bool status = false;
            try
            {
                foreach (var item in cache)
                {
                    cache.Remove(item.Key);
                }
            }
            catch
            {
            }
            return status;
        }

        public bool AddItemToCache<T>(string key, T item)
        {
            bool status = false;
            try
            {
                List<T> cachedObjects = cache[key] as List<T>;
                cachedObjects.Add(item);
                if (cachedObjects == null)
                {
                    cache.Set(key, cachedObjects, cacheExpiry);
                }
                else
                {
                    cache.Add(key, item, cacheExpiry);
                }
                status = true;
            }
            catch
            {

            }
            return status;
        }

    }
}