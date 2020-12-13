using System;
using System.Linq;
using FigureStorage.API.Extensions;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace FigureStorage.API.Binders
{
    public class InheritorsToBaseTypeJsonConverter<T> : JsonCreationConverter<T>
    {
        private static Type[] s_inheritors;
        static InheritorsToBaseTypeJsonConverter()
        {
            s_inheritors = typeof(T).GetAllDerived().ToArray();
        }
        protected override T Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");
            
            var requestedType = jObject["type"]?.ToString()?.Pascalize();

            var type = s_inheritors.FirstOrDefault(e => e.Name == requestedType);
            
            return (T)type?.CreateWithDefaultCtor();
        }
    }
}