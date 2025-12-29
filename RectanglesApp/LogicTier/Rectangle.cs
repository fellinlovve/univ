using System;

namespace LogicTier
{
    public class Rectangle
    {
        public double SideA { get; set; }
        public double SideB { get; set; }

        public Rectangle(double a, double b)
        {
            SideA = a;
            SideB = b;
        }

        public double GetArea() => SideA * SideB;

        public double GetDiagonal() => Math.Sqrt(SideA * SideA + SideB * SideB);

        public override string ToString() => $"a={SideA}, b={SideB}";
    }
}