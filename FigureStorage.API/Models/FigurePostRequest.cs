using FigureStorage.Models;

namespace FigureStorage.API.Models
{
    public class FigurePostRequest
    {
        public string Type { get; set; }
        public Figure Figure { get; set; }
    }
}