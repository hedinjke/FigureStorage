using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FigureStorage.Models;
using Xunit;

namespace FigureStorage.Test.Figures
{
    public class RectangleTest
    {
         [Fact]
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public void CtorDefault()
        {
            var rectangle = new Rectangle();

            Assert.True(rectangle.Area == 0);
            Assert.False(rectangle.IsValid);
        }
        
        [Fact]
        public void Validation()
        {
            var rectangle = new[]
            {
                new Rectangle(double.Epsilon), 
                new Rectangle(10), 
                new Rectangle(20), 
                new Rectangle(90), 
                new Rectangle(double.MaxValue), 
            };

            Assert.All(rectangle, triangle => Assert.True(triangle.IsValid, $"{triangle} should be valid."));

            var badRects = new Func<Figure>[]
            {
                () => new Rectangle(-double.Epsilon), 
                () => new Rectangle(-1), 
                () => new Rectangle(-50), 
                () => new Rectangle(-double.MaxValue), 
            };
            
            Assert.All(badRects, triangle =>
            {
                var ex = Assert.Throws<ArgumentException>(triangle);
                Assert.Equal("Rectangle is not valid.", ex.Message);
            });
        }
        
        [Fact]
        public void Area()
        {
            var rects = new[]
            {
                new Rectangle(0.5), 
                new Rectangle(20), 
                new Rectangle(55), 
                new Rectangle(168), 
     
            };
            
            double GetArea(Rectangle t)
            {
                return Math.PI * t.Radius * t.Radius;
            }

            Assert.All(rects, rect => Assert.True(rect.Area - GetArea(rect) < double.Epsilon));
        }
        
        [Fact]
        public void TypeProperty()
        {
            var triangle = new Rectangle();
            Assert.True(triangle.Type == "Rectangle");
            Assert.True(triangle.Type == triangle.GetType().Name);
        }
        
        [Fact]
        public void IsFigure()
        {
            var rect = new Rectangle();
            Assert.IsAssignableFrom<Figure>(rect);
        }
    }
}