using System.Linq;
using AutoMapper;
using AutoMapper.Internal;
using FigureStorage.API.Extensions;

namespace FigureStorage.API.Mapper
{
    public static class MapperProfileExtensions
    {
        public static IMappingExpression<TType, TTypeDTO> MapDtoWithDerived<TType, TTypeDTO>(this Profile profile)
        {
            var name = nameof(TType);
            var nameDTO = nameof(TTypeDTO);
            var postfix = nameDTO.Substring(name.Length);
            
            var types = typeof(TType).GetAllDerived();
            var typesDTO = typeof(TTypeDTO).GetAllDerived();
                
            types.ForAll(type =>
            {
                var typeDTO = typesDTO.FirstOrDefault(dto => dto.Name == type.Name + postfix);
                
                if (typeDTO != null) profile.CreateMap(type, typeDTO).IncludeAllDerived();
            });

            return profile.CreateMap<TType, TTypeDTO>().IncludeAllDerived();
        }
    }
}