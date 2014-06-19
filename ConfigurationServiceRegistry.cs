using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escc.Services
{
    /// <summary>
    /// Reads type names for services from .NET configuration files
    /// </summary>
    public class ConfigurationServiceRegistry : IServiceRegistry
    {
        /// <summary>
        /// Reads the fully qualified type name for a class implementing the specified interface.
        /// </summary>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <returns></returns>
        /// <exception cref="System.Configuration.ConfigurationErrorsException"></exception>
        public string ReadTypeNameForInterface(Type interfaceType)
        {
            var config = ConfigurationManager.GetSection("Escc.Services/ServiceLocator") as NameValueCollection;
            if (config == null || String.IsNullOrEmpty(config[interfaceType.ToString()]))
            {
                throw new ConfigurationErrorsException(interfaceType + " has not been configured in web.config");
            }
            return config[interfaceType.ToString()];
        }
    }
}
