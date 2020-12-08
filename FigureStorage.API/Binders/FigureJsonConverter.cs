﻿using System;
using System.Linq;
using FigureStorage.API.Extensions;
using FigureStorage.Models;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace FigureStorage.API.Binders
{
    public class FigureJsonConverter : JsonCreationConverter<Figure>
    {
        private static Type[] s_inheritors;
        static FigureJsonConverter()
        {
            s_inheritors = typeof(Figure).GetInheritors().ToArray();
        }
        protected override Figure Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");
            
            var type = jObject["type"].ToString().Pascalize();
            return type switch
            {
                nameof(Rectangle) => new Rectangle(),
                nameof(Triangle)  => new Triangle(),
                _                 => null
            };
        }
    }
}