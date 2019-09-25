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

    }
}
