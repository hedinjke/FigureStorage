using System.ComponentModel.DataAnnotations.Schema;

namespace FigureStorage.Models
{
    [Table("Squares")]
    public class Square : Figure
    {
        public double Side { get; set; }
        public override string Type => GetType().Name;
        public override double Area => Side * Side;
        public override bool IsValid => Side > 0;
    }
}