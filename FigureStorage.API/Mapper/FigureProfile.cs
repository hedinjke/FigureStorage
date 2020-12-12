using AutoMapper;
using FigureStorage.DTO;
using FigureStorage.Models;


namespace FigureStorage.API.Mapper
{
    public class FigureProfile : Profile
    {
        public FigureProfile()
        {
           this.MapDtoWithDerived<Figure, FigureDTO>();
        }

        public override string ProfileName { get; } = "Figure";
    }
}