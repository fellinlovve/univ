using System;
using System.Threading;

namespace Lab22_Task19
{
    // 1. Объявляем пользовательский делегат
    public delegate int CountOccurrencesDelegate(double[,] matrix, double target);

    class Program
    {
        // 2. Метод, который будет выполняться асинхронно
        public static int CountOccurrences(double[,] matrix, double target)
        {
            Console.WriteLine("Асинхронный метод: начало подсчёта...");
            Thread.Sleep(2000); // имитация длительной операции

            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    // Сравнение вещественных чисел с учётом погрешности
                    if (Math.Abs(matrix[i, j] - target) < 1e-9)
                        count++;
                }
            }

            Console.WriteLine("Асинхронный метод: подсчёт завершён.");
            return count;
        }

        static void Main(string[] args)
        {
            // 3. Создаём тестовую матрицу
            double[,] matrix = {
                { 1.1, 2.3, 3.7 },
                { 2.3, 4.5, 2.3 },
                { 6.0, 2.3, 8.1 }
            };
            double target = 2.3;

            // 4. Создаём делегат
            CountOccurrencesDelegate del = new CountOccurrencesDelegate(CountOccurrences);

            // 5. Асинхронный запуск
            Console.WriteLine("Запуск асинхронного метода...");
            IAsyncResult result = del.BeginInvoke(matrix, target, null, null);

            // 6. Имитация работы основного потока
            Console.WriteLine("Основной поток: ожидание завершения...");
            while (!result.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }
            Console.WriteLine();

            // 7. Получение результата
            int occurrences = del.EndInvoke(result);
            Console.WriteLine($"Элемент {target} встречается в матрице {occurrences} раз(а).");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}