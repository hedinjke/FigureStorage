using FigureStorage.Models;

namespace FigureStorage.Repo.Validation
{
    public class RectangleValidator : IFigureValidator<Rectangle>
    {
        private readonly Rectangle _rectangle;

        public RectangleValidator(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public bool Validate(Rectangle figure)
        {
            return true;
        }
    }
}