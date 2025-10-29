using System;
using System.IO;


namespace lab__5
{
    class Programm
    {
        static void Main(string[] args)
        {
            int N, M;

            Console.Write("Inter N > ");
            N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inter M > ");
            M = Convert.ToInt32(Console.ReadLine());

            TextWriter save_out = Console.Out;
            var new_out = new StreamWriter(@"massive.txt");
            Console.SetOut(new_out);

            Console.WriteLine(N);
            Console.WriteLine(M);

            Random r = new Random();
            int x = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    x = r.Next(1000);
                    Console.Write(x + " ");
                }
                Console.WriteLine();
            }

            Console.SetOut(save_out); new_out.Close();
            Console.WriteLine("Файл massiv.txt размерностью {0} Х {1} был создан!", N, M);
            Run();
            Console.WriteLine("Обработка завершена. Результат записан в output.txt.");
            Console.ReadKey();
        }

        static void Run()
        {
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"massive.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);

            int N = Convert.ToInt32(Console.ReadLine());
            int M = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"***Input matrix with {N} x {M} size***");

            int[,] mas = new int [N, M];
            for (int i = 0; i < N; i++)
            {
                String str_all = Console.ReadLine();
                string[] str_elem = str_all.Split(' ');
                for (int j = 0;j < M; j++)
                {
                    mas[i,j] = Convert.ToInt32(str_elem[j]);
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0;i < N; i++)
            {
                int s = 0;
                double sa = 0;
                for (int j = 0; j < M; j++)
                {
                    s += mas[i,j];
                    sa = s / N;
                }
                Console.WriteLine("Среднее арифметическое {0}-ой строки равно {1}", i + 1, sa);
            }

            for (int i = 0; i < N; i++)
            {
                int s = 0;
                double sa = 0;
                for (int j = 0; j < M; j++)
                {
                    s += mas[i, j];
                    sa = s / N;
                    if (mas[i,j] > sa)
                    {
                        Console.Write("U ");
                    }
                    else
                    {
                        Console.Write("X ");
                    }
                }
                Console.WriteLine();
            }

            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
        }
    }

}