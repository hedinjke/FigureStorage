using FigureStorage.Models;

namespace FigureStorage.API.Models
{
    public class FigurePostResponse
    {
        public FigurePostResponse(Figure figure)
        {
            Id = figure.Id;
        }

        public int Id { get; }
    }
}