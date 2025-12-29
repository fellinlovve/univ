using System;
using System.Threading;

namespace Lab23_Task19
{
    // Структура для передачи параметров
    public struct MatrixParams
    {
        public int Rows;
        public int Cols;
    }

    class Program
    {
        // Метод, который будет выполняться в потоке
        static void CalculateAverage(object data)
        {
            var mp = (MatrixParams)data;
            Random rand = new Random();
            double sum = 0;
            int total = mp.Rows * mp.Cols;

            // Создаём и заполняем матрицу случайными числами
            double[,] matrix = new double[mp.Rows, mp.Cols];
            for (int i = 0; i < mp.Rows; i++)
            {
                for (int j = 0; j < mp.Cols; j++)
                {
                    matrix[i, j] = rand.NextDouble() * 100;
                    sum += matrix[i, j];
                }
            }

            double average = sum / total;
            Console.WriteLine($"Среднее арифметическое матрицы {mp.Rows}x{mp.Cols}: {average:F2}");
        }

        static void Main(string[] args)
        {
            // Ввод размеров матрицы
            Console.Write("Введите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int cols = int.Parse(Console.ReadLine());

            // Упаковка параметров
            MatrixParams mp = new MatrixParams { Rows = rows, Cols = cols };

            // Создание и запуск потока
            Thread thread = new Thread(new ParameterizedThreadStart(CalculateAverage));
            thread.Start(mp);

            // Ожидание завершения потока
            thread.Join();

            Console.WriteLine("Поток завершил выполнение.");
            Console.ReadKey();
        }
    }
}