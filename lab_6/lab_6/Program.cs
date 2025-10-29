using System;
using System.IO;

namespace lab_6
{
    class Sphere
    {
        //вычисление:
        //объема S сферы = 4/3 ⋅ π ⋅ R^3 .
        //диаметра r * 2
        //площади поверхности; S сферы = 4 ⋅ π ⋅ R^2 .
        //вывод информации об объекте
        const double pi = 3.141592;
        private double R;
        
        public double GetV()
        {
            return 4 / 3 * pi * R * R * R;
        }

        public double GetS() 
        {
            return 4 * pi * R * R;
        }

        public double GetD()
        {
            return R * 2;
        }
        public void Info()
        {
            Console.WriteLine("***--СФЕРА--***");
            Console.WriteLine("При радиусе, равном {0}, сфера имеет следующие характеристики: ", R);
            Console.WriteLine(string.Format("V (объем) = {0}", GetV()));
            Console.WriteLine(string.Format("S (площадь) = {0}", GetS()));
            Console.WriteLine(string.Format("D (диаметр) = {0}", GetD()));
        }

        public void SetInfo()
        {
            Console.Write("Введите значение радиуса: ");
            R = Convert.ToDouble(Console.ReadLine());
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
#if !DEBUG
            TextWriter save_out = Console.Out;
            TextReader save_in = Console.In;
            var new_out = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(@"input.txt");
            Console.SetOut(new_out);
            Console.SetIn(new_in);
#endif
            Sphere s = new Sphere();
            s.SetInfo();
            s.Info();
#if !DEBUG
            Console.SetOut(save_out); new_out.Close();
            Console.SetIn(save_in); new_in.Close();
#else
            Console.ReadKey();
#endif
        }
    }
}