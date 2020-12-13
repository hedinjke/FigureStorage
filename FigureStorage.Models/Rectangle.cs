using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FigureStorage.Models
{
    [Table("Rectangles")]
    public class Rectangle : Figure
    {
        public Rectangle() { }
        /// <summary>
        /// Create rectangle with given radius.
        /// Throws <see cref="ArgumentException"/> if rectangle is not valid.
        /// </summary>
        /// <param name="radius"></param>
        /// <exception cref="ArgumentException"></exception>
        public Rectangle(double radius)
        {
            Radius = radius;
            if (!Validate())
                throw new ArgumentException("Rectangle is not valid.");
        }

        public double Radius { get; set; }
        public override string Type => GetType().Name;
        public override double Area => Radius * Radius * Math.PI;

        public override bool IsValid => Validate();

        private bool Validate()
        {
            return Radius > 0;
        }

        public override string ToString()
        {
            return $"Rectangle: R{Radius}";
        }
    }
}