using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FigureStorage.API.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Get all derived non-abstract subclasses of given type./>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetAllDerived(this Type type)
        {
            return Assembly.GetAssembly(type)
                          ?.GetTypes()
                           .Where(myType => myType.IsClass &&
                                            !myType.IsAbstract &&
                                            myType.IsSubclassOf(type));
        }
        
        /// <summary>
        /// Creates instance of given using default ctor.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object CreateWithDefaultCtor(this Type type)
        {
            return Activator.CreateInstance(type, false);
        }
    }
}