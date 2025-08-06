using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Text;

namespace task1
{
    internal class Program
    {
        static void Main()
        {
            int n;
            int m;
            var initmass = (int n, int m) =>
            {
                int[] interval = new int[m];
                int index = 1;
                for (int i = 0; i < m; i++)
                {
                    if (index > n)
                    {
                        index = 1;
                        interval[i] = index;
                    }
                    else interval[i] = index;

                    index += 1;
                }
                return interval;
            };
            var procces = (int[] interval, int m, int n) =>
            {
                int result = 0;
                int indexlast = interval.Length - 1;
                StringBuilder strresult = new StringBuilder("1");
                if (interval[indexlast] == 1) result = 1;
                while (result == 0)
                {
                    int indexThisInterval = 0;
                    while (indexThisInterval < m)
                    {
                        if (indexThisInterval == 0)
                        {
                            interval[indexThisInterval] = interval[indexlast];
                        }
                        else
                        {
                            int number = interval[indexThisInterval - 1] + 1;
                            if (number <= n) interval[indexThisInterval] = interval[indexThisInterval - 1] + 1;
                            else interval[indexThisInterval] = 1;
                        }
                        indexThisInterval++;
                    }
                
                    if (interval[indexlast] == 1)
                    {
                        strresult.Append(interval[0].ToString());
                        result = 1;
                    }
                    else strresult.Append(interval[0]);
                    
                  
                }
                Console.WriteLine($"Полученный путь:{strresult.ToString()}");
            };
            while (true)
            {
                try
                {
                    Console.Write("\nn=");
                    n = System.Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");
                    Console.Write("m=");
                    m = System.Convert.ToInt32(Console.ReadLine());

                    int[] interval = initmass.Invoke(n, m);
                    procces.Invoke(interval, m, n);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}
