using System;
using MatrixLib;

namespace MatrixApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №10 — Вариант 19");
                Console.WriteLine("Сумма первой матрицы и транспонированной второй.");

                // Размер матриц (для примера 3x3)
                const int N = 3, M = 3;

                // Загрузка первой матрицы
                var matrix1 = new Matrix(N, M);
                matrix1.LoadFromFile("matrix1.txt");

                // Загрузка второй матрицы
                var matrix2 = new Matrix(N, M);
                matrix2.LoadFromFile("matrix2.txt");

                // Транспонирование второй матрицы
                var transposed = matrix2.Transpose();

                // Сложение
                var result = matrix1.Add(transposed);

                // Вывод результата
                Console.WriteLine("\nРезультат (матрица суммы):");
                result.Print();

                // Сохранение в файл
                result.SaveToFile("result.txt");
                Console.WriteLine("\nРезультат сохранён в файл 'result.txt'.");

                Console.WriteLine("\nНажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}