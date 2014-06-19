using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escc.Services
{
    /// <summary>
    /// A place to find type names for services
    /// </summary>
    public interface IServiceRegistry
    {
        /// <summary>
        /// Reads the fully qualified type name for a class implementing the specified interface.
        /// </summary>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <returns></returns>
        string ReadTypeNameForInterface(Type interfaceType);
    }
}
