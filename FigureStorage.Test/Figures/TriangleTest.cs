using System;
using System.Diagnostics.CodeAnalysis;
using FigureStorage.Models;
using Xunit;

namespace FigureStorage.Test.Figures
{
    public class TriangleTest
    {
        [Fact]
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public void CtorDefault()
        {
            var triangle = new Triangle();

            Assert.True(triangle.SideA == 0);
            Assert.True(triangle.SideB == 0);
            Assert.True(triangle.SideC == 0);
            Assert.False(triangle.IsValid);
        }
        
        [Fact]
        public void Validation()
        {
            var triangles = new[]
            {
                new Triangle(17, 9, 9),
                new Triangle(20, 40, 21),
                new Triangle(16, 15, 30),
                new Triangle(1, 1, 1),
            };

            Assert.All(triangles, triangle => Assert.True(triangle.IsValid, $"{triangle} should be valid."));

            var badTriangles = new Func<Figure>[]
            {
                () => new Triangle(0, 1, 1),
                () => new Triangle(1, 0, 1),
                () => new Triangle(1, 1, 0),
                () => new Triangle(-double.Epsilon, 1, 1),
                () => new Triangle(1, -double.Epsilon, 1),
                () => new Triangle(1, 1, -double.Epsilon),
                () => new Triangle(-double.MaxValue, 1, 1),
                () => new Triangle(1, -double.MaxValue, 1),
                () => new Triangle(1, 1, -double.MaxValue),
                () => new Triangle(4, 2, 2),
                () => new Triangle(2, 4, 2),
                () => new Triangle(2, 2, 4),
                () => new Triangle(50, 50, 100),
                () => new Triangle(50, 100, 50),
                () => new Triangle(100, 50, 50),
            };
            
            Assert.All(badTriangles, triangle =>
            {
                var ex = Assert.Throws<ArgumentException>(triangle);
                Assert.Equal("Triangle is not valid.", ex.Message);
            });
        }
        
        [Fact]
        public void Area()
        {
            var triangles = new[]
            {
                new Triangle(17, 20, 13),
                new Triangle(18, 22, 13),
                new Triangle(35, 41, 49),
                new Triangle(16, 13, 20),
            };
            
            double GetArea(Triangle t)
            {
                var perimeter = t.SideA + t.SideB + t.SideC;
                return Math.Sqrt(perimeter * (perimeter - t.SideA) * (perimeter - t.SideB) * (perimeter - t.SideC));
            }

            Assert.All(triangles, triangle => Assert.True(Math.Abs(triangle.Area - GetArea(triangle)) < double.Epsilon));
        }
        
        [Fact]
        public void TypeProperty()
        {
            var triangle = new Triangle();
            Assert.True(triangle.Type == "Triangle");
            Assert.True(triangle.Type == triangle.GetType().Name);
        }
        
        [Fact]
        public void IsFigure()
        {
            var triangle = new Triangle();
            Assert.IsAssignableFrom<Figure>(triangle);
        }
    }
}