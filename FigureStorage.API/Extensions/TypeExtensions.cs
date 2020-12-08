using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FigureStorage.API.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetInheritors(this Type type)
        {
            return Assembly.GetAssembly(type)
                          ?.GetTypes()
                           .Where(myType => myType.IsClass &&
                                            !myType.IsAbstract &&
                                            myType.IsSubclassOf(type));
        }
        
        public static object CreateWithDefaultCtor(this Type type)
        {
            return Activator.CreateInstance(type, false);
        }
    }
}