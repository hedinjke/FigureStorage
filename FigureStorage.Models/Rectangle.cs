﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FigureStorage.Models
{
    [Table("Rectangles")]
    public class Rectangle : Figure
    {
        public Rectangle()
        {
        }

        public Rectangle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }
        public override string Type => GetType().Name;
        public override double Area => Radius * Radius * Math.PI;

        public override bool IsValid => Validate();

        private bool Validate()
        {
            return Radius > 0;
        }
    }
}