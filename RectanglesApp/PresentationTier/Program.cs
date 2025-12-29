using System;
using System.Collections.Generic;
using LogicTier;

namespace PresentationTier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Анализ прямоугольников\n");
            Console.Write("Введите количество прямоугольников: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Некорректное количество.");
                return;
            }

            var rectangles = new List<Rectangle>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nПрямоугольник {i + 1}:");
                Console.Write("Сторона a: ");
                if (!double.TryParse(Console.ReadLine(), out double a) || a <= 0)
                {
                    Console.WriteLine("Некорректное значение стороны a.");
                    return;
                }

                Console.Write("Сторона b: ");
                if (!double.TryParse(Console.ReadLine(), out double b) || b <= 0)
                {
                    Console.WriteLine("Некорректное значение стороны b.");
                    return;
                }

                rectangles.Add(new Rectangle(a, b));
            }

            try
            {
                var maxArea = RectangleAnalyzer.FindMaxAreaRectangle(rectangles);
                var maxDiag = RectangleAnalyzer.FindMaxDiagonalRectangle(rectangles);

                Console.WriteLine("\nРезультаты анализа:");
                Console.WriteLine($"Прямоугольник с наибольшей площадью: {maxArea}, площадь = {maxArea.GetArea():F2}");
                Console.WriteLine($"Прямоугольник с наибольшей диагональю: {maxDiag}, диагональ = {maxDiag.GetDiagonal():F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}