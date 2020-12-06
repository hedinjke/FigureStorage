using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FigureStorage.Models
{
    [Table("Triangles")]
    public class Triangle : Figure
    {
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

        [Required] public double SideA { get; private set; }
        [Required] public double SideB { get; private set; }
        [Required] public double SideC { get; private set; }

        public override double Area => GetArea();
        
        public override bool IsValid => Validate();

        private double GetArea()
        {
            var perimeter = SideA + SideB + SideC;
            return Math.Sqrt(perimeter * (perimeter - SideA) * (perimeter - SideB) * (perimeter - SideC));
        }

        private bool Validate()
        {
            return !(SideA + SideB <= SideC ||
                     SideA + SideC <= SideB ||
                     SideB + SideC <= SideA);
        }
    }
}