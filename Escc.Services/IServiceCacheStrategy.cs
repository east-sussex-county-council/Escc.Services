using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escc.Services
{
    /// <summary>
    /// A method of caching services created by <see cref="ServiceLocator" />
    /// </summary>
    public interface IServiceCacheStrategy
    {
        /// <summary>
        /// Adds a service to the cache.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="serviceInstance">The service instance.</param>
        void AddToCache(string cacheKey, object serviceInstance);

        /// <summary>
        /// Reads a service from the cache.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <returns></returns>
        object ReadFromCache(string cacheKey);
    }
}
