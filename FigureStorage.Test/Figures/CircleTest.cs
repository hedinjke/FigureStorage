using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FigureStorage.Models;
using Xunit;

namespace FigureStorage.Test.Figures
{
    public class CircleTest
    {
        [Fact]
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public void CtorDefault()
        {
            var circle = new Circle();

            Assert.True(circle.Area == 0);
            Assert.False(circle.IsValid);
        }

        [Fact]
        public void Validation()
        {
            var circles = new[]
            {
                new Circle(double.Epsilon),
                new Circle(10),
                new Circle(20),
                new Circle(90),
                new Circle(double.MaxValue),
            };

            Assert.All(circles, circle => Assert.True(circle.IsValid, $"{circle} should be valid."));

            var badCircles = new Func<Figure>[]
            {
                () => new Circle(-double.Epsilon),
                () => new Circle(-1),
                () => new Circle(-50),
                () => new Circle(-double.MaxValue),
            };

            Assert.All(badCircles, circle =>
            {
                var ex = Assert.Throws<ArgumentException>(circle);
                Assert.Equal("Circle is not valid.", ex.Message);
            });
        }

        [Fact]
        public void Area()
        {
            var circles = new[]
            {
                new Circle(0.5),
                new Circle(20),
                new Circle(55),
                new Circle(168)
            };

            double GetArea(Circle t)
            {
                return Math.PI * t.Radius * t.Radius;
            }

            Assert.All(circles, circle => Assert.True(circle.Area - GetArea(circle) < double.Epsilon));
        }

        [Fact]
        public void TypeProperty()
        {
            var circle = new Circle();
            Assert.True(circle.Type == "Circle");
            Assert.True(circle.Type == circle.GetType().Name);
        }

        [Fact]
        public void IsFigure()
        {
            var circle = new Circle();
            Assert.IsAssignableFrom<Figure>(circle);
        }
    }
}