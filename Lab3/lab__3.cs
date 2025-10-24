using System;
using System.IO;
class HelloWorld {
      static void Main() {
          TextWriter save_out = Console.Out;
          TextReader save_in = Console.In;
          var new_out = new StreamWriter(@"output.txt");
          var new_in = new StreamReader(@"input.txt");
          Console.SetOut(new_out);
          Console.SetIn(new_in);
          
          int t, n, iter, znam = 1, i = 1;
          double Z, X, Y, znach;
          
          t = Convert.ToInt32(Console.ReadLine());
          n = Convert.ToInt32(Console.ReadLine());
          X = Convert.ToDouble(Console.ReadLine());
          Y = Convert.ToDouble(Console.ReadLine());
          Z=0;
          
          if (t == 0)
          {
              for(i = 1; i <=n; i++)
              {
                  znam *= i;
                  if (i % 2 == 0)
                      znach = -((Math.Pow(Math.Cos(Y), i) + Math.Abs(X)) / znam);
                  else
                      znach = (Math.Pow(Math.Cos(X), i) + Math.Abs(Y)) / znam;
                  Z += znach;
              }
          }
          if (t == 1)
          {
              while (i <= n)
              {
                  znam *= i;
                  if (i % 2 == 0)
                      znach = -((Math.Pow(Math.Cos(Y), i) + Math.Abs(X)) / znam);
                  else
                      znach = (Math.Pow(Math.Cos(X), i) + Math.Abs(Y)) / znam;
                  Z += znach;
                  i++;
              }
          }
          if (t == 2)
          {
              do 
              {
                  znam *= i;
                  if (i % 2 == 0)
                      znach = -((Math.Pow(Math.Cos(Y), i) + Math.Abs(X)) / znam);
                  else
                      znach = (Math.Pow(Math.Cos(X), i) + Math.Abs(Y)) / znam;
                  Z += znach;
                  i++;
              } while (i <= n);
          }
          
          Console.WriteLine(String.Format("{0:0.0000000}", Z));
          Console.SetOut(save_out); new_out.Close();
          Console.SetIn(save_in); new_in.Close();
      }
}