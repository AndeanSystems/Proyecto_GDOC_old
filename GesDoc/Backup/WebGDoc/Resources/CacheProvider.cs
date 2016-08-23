using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace WebGdoc.Resources
{
    public class CacheProvider
    {
        private readonly Cache _cache;

        public CacheProvider(Cache cache)
        {
            _cache = cache;
        }

        public CacheProvider()
            : this(HttpRuntime.Cache)
        {

        }
        public void Set(string key, object obj)
        {
            if (key == null || obj == null)
                return;
            _cache.Insert(key, obj, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

    }
}
