using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FigureStorage.Models
{
    [Table("Circles")]
    public class Circle : Figure
    {
        public Circle() { }
        /// <summary>
        /// Create circle with given radius.
        /// Throws <see cref="ArgumentException"/> if circle is not valid.
        /// </summary>
        /// <param name="radius"></param>
        /// <exception cref="ArgumentException"></exception>
        public Circle(double radius)
        {
            Radius = radius;
            if (!Validate())
                throw new ArgumentException("Circle is not valid.");
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
            return $"Rircle: R{Radius}";
        }
    }
}