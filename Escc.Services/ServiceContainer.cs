using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Caching;

namespace Escc.Services
{
    /// <summary>
    /// Load common services used by applications
    /// </summary>
    public static class ServiceContainer
    {
        /// <summary>
        /// Loads a service based on its interface type
        /// </summary>
        /// <typeparam name="T">The type of service to load</typeparam>
        /// <param name="serviceRegistry">Where to find the service</param>
        /// <param name="cacheStrategy">How to cache the service instance, if at all</param>
        /// <returns>An instance of the service</returns>
        public static T LoadService<T>(IServiceRegistry serviceRegistry, IServiceCacheStrategy cacheStrategy=null)
        {
            var cacheKey = typeof (T).ToString();
            if (cacheStrategy != null)
            {
                var cached = cacheStrategy.ReadFromCache(cacheKey);
                if (cached != null) return (T)cached;
            }

            var typeName = serviceRegistry.ReadTypeNameForInterface(typeof (T));
            var service = (T)CreateInstanceFromFullyQualifiedName(typeName);

            if (cacheStrategy != null)
            {
                cacheStrategy.AddToCache(cacheKey, service);
            }

            return service;
        }

        /// <summary>
        /// Creates an instance of a type from its fully qualified type name
        /// </summary>
        /// <param name="fullyQualifiedType">Type of the fully qualified.</param>
        /// <returns></returns>
        private static object CreateInstanceFromFullyQualifiedName(string fullyQualifiedType)
        {
            if (String.IsNullOrEmpty(fullyQualifiedType)) throw new ArgumentNullException("fullyQualifiedType");

            var comma = fullyQualifiedType.IndexOf(",", StringComparison.OrdinalIgnoreCase);
            if (comma == -1)
            {
                throw new ArgumentException("Specify a type in the format: Namespace.TypeName, AssemblyName, Version=x.x.x.x, Culture=neutral, PublicKeyToken=xxx", "fullyQualifiedType");
            }

            var typeName = fullyQualifiedType.Substring(0, comma).Trim();
            var assemblyName = fullyQualifiedType.Substring(comma).Trim(new char[] {',', ' '});

            var assembly = Assembly.Load(assemblyName);
            return assembly.CreateInstance(typeName);
        }
    }
}