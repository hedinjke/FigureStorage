using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FigureStorage.Models
{
    [Table("Triangles")]
    public class Triangle : Figure
    {
        public Triangle()
        {
        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA + sideB <= sideC ||
                sideA + sideC <= sideB ||
                sideB + sideC <= sideA)
                throw new ArgumentException("Triangle is not valid.");
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
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
    }
}