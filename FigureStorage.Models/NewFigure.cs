using System.ComponentModel.DataAnnotations.Schema;

namespace FigureStorage.Models
{
    [Table("NewFigure")]
    public class NewFigure : Figure
    {
        public NewFigure() { }
        public double Side { get; set; }
        public override string Type => GetType().Name;
        public override double Area => Side * Side;
        public override bool IsValid => Side > 0;
    }
}