using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicTier
{
    public static class RectangleAnalyzer
    {
        public static Rectangle FindMaxAreaRectangle(List<Rectangle> rectangles)
        {
            if (rectangles == null || rectangles.Count == 0)
                throw new ArgumentException("Список прямоугольников пуст.");

            return rectangles.OrderByDescending(r => r.GetArea()).First();
        }

        public static Rectangle FindMaxDiagonalRectangle(List<Rectangle> rectangles)
        {
            if (rectangles == null || rectangles.Count == 0)
                throw new ArgumentException("Список прямоугольников пуст.");

            return rectangles.OrderByDescending(r => r.GetDiagonal()).First();
        }
    }
}