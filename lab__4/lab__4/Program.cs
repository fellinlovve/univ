using System;
using System.IO;


namespace lab__4
{
    class FileGenerator
    {
        static void Main(string[] args)
        {
            int N;
            String FileName;

            Console.Write("Inter N > ");
            N = Convert.ToInt32(Console.ReadLine());

            TextWriter save_out = Console.Out;
            var new_out = new StreamWriter(@"massive.txt");
            Console.SetOut(new_out);

            Console.WriteLine(N);

            Random r = new Random();
            int x = 0;
            for (int i = 0; i < N; i++)
            {
                x = r.Next(1000);
                Console.Write(x + " ");
            }

            Console.SetOut(save_out); new_out.Close();
            Console.WriteLine("Файл massiv.txt с {0} элементом (-ами) был создан!", N);
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

            int n = Convert.ToInt32(Console.ReadLine());
            String str_all = Console.ReadLine();
            string[] str_elem = str_all.Split(' ');

            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                mas[i] = Convert.ToInt32(str_elem[i]);
            }


            int max_nechet = 0;

            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 2 != 0 && mas[i] > max_nechet)
                    max_nechet = mas[i];
            }

            Console.WriteLine("Максимальный нечёный элемен равен {0}", max_nechet);

            
            double summ = 0;

            for (int i = 0; i < mas.Length; i++)
            {
                summ += Convert.ToDouble(mas[i]);
            }
            double sred = summ / mas.Length;

            Console.WriteLine("Среднее арифмеическое равно {0}", sred);

            Console.Write("Список чётных элементов: ");

            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 2 == 0)
                    Console.Write(mas[i] + " ");
            }

            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
        }
    }

}
