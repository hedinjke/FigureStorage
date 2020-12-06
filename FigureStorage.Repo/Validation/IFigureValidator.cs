using FigureStorage.Models;

namespace FigureStorage.Repo.Validation
{
    public interface IFigureValidator<in T>
        where T : Figure
    {
        bool Validate(T figure);
    }
}