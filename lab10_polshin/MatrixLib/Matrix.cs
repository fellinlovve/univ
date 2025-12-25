using System;
using System.IO;
using System.Linq;

namespace MatrixLib
{
    public class Matrix
    {
        public double[,] Data { get; private set; }
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Размеры матрицы должны быть положительными.");
            Rows = rows;
            Cols = cols;
            Data = new double[rows, cols];
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException($"Файл {filename} не найден.");

            var lines = File.ReadAllLines(filename);
            if (lines.Length != Rows)
                throw new InvalidOperationException("Несоответствие числа строк в файле и матрице.");

            for (int i = 0; i < Rows; i++)
            {
                var parts = lines[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != Cols)
                    throw new InvalidOperationException($"Несоответствие числа столбцов в строке {i + 1}.");
                for (int j = 0; j < Cols; j++)
                    Data[i, j] = double.Parse(parts[j]);
            }
        }

        public void SaveToFile(string filename)
        {
            var lines = new string[Rows];
            for (int i = 0; i < Rows; i++)
            {
                lines[i] = string.Join(" ", Enumerable.Range(0, Cols).Select(j => Data[i, j].ToString("F2")));
            }
            File.WriteAllLines(filename, lines);
        }

        public Matrix Transpose()
        {
            var result = new Matrix(Cols, Rows);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    result.Data[j, i] = Data[i, j];
            return result;
        }

        public Matrix Add(Matrix other)
        {
            if (Rows != other.Rows || Cols != other.Cols)
                throw new ArgumentException("Размеры матриц не совпадают.");
            var result = new Matrix(Rows, Cols);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    result.Data[i, j] = Data[i, j] + other.Data[i, j];
            return result;
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    Console.Write($"{Data[i, j],8:F2} ");
                Console.WriteLine();
            }
        }
    }
}