using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Escc.Services
{
    /// <summary>
    /// Caches services using the application cache provided by <see cref="HttpContext"/>
    /// </summary>
    public class HttpContextCacheStrategy : IServiceCacheStrategy
    {
        /// <summary>
        /// Adds a service to the cache.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="serviceInstance">The service instance.</param>
        public void AddToCache(string cacheKey, object serviceInstance)
        {
            HttpContext.Current.Cache.Insert(cacheKey, serviceInstance, null, DateTime.Today.AddDays(1), Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// Reads a service from the cache.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <returns></returns>
        public object ReadFromCache(string cacheKey)
        {
            if (HttpContext.Current != null && HttpContext.Current.Cache[cacheKey] != null)
            {
                return HttpContext.Current.Cache[cacheKey];
            }
            return null;
        }
    }
}
