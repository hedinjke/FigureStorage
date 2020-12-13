using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FigureStorage.Models
{
    [Table("Triangles")]
    public class Triangle : Figure
    {
        public Triangle() { }

        /// <summary>
        /// Create triangle from 3 given sides.
        /// Throw <see cref="ArgumentException"/> if triangle is not valid.
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            if (!Validate())
                throw new ArgumentException("Triangle is not valid.");
        }

        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public override string Type => GetType().Name;
        public override double Area => GetArea();

        public override bool IsValid => Validate();

        private double GetArea()
        {
            var perimeter = SideA + SideB + SideC;
            return Math.Sqrt(perimeter * (perimeter - SideA) * (perimeter - SideB) * (perimeter - SideC));
        }

        private bool Validate()
        {
            var positiveSides = SideA > 0 && SideB > 0 && SideC > 0;
            var canBeCreated =
                SideA + SideB > SideC &&
                SideA + SideC > SideB &&
                SideB + SideC > SideA;
            return positiveSides && canBeCreated;
        }

        public override string ToString()
        {
            return $"Triangle: A{SideA} B{SideB} C{SideC}";
        }
    }
}