using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // параметр -n и параметр -m
           //пример dotnet run -n 4 -m 5
            int n;
            int m;
            ReadArgs(out n, out m, args);
            if (n == 0 && m == 0)
            {
                Console.WriteLine("ошибка");
                Console.ReadKey();
                System.Environment.Exit(0);
            }

            List<int> Intervals = new List<int>();
            int FirstObjectIndex = 0;
   
            while (FirstObjectIndex != 1)
            {
                if (FirstObjectIndex == 0)
                {
                    Intervals.Add(1);
                    FirstObjectIndex = FirstObjectIndex + (m);
                }
                else
                    FirstObjectIndex = FirstObjectIndex + (m - 1);
                if (FirstObjectIndex > n)
                {
                    FirstObjectIndex = FirstObjectIndex - n;
                }
                Intervals.Add(FirstObjectIndex);
            }
            Intervals.RemoveAt(Intervals.Count-1);
            foreach (int i in Intervals)
            {
                Console.Write(i+" ");
            }


        }
        static void ReadArgs(out int n, out int m, string[] args)
        {
            n = 0;
            m = 0;
            for (int i = 0; i < args.Length; i++)
            {
                //Проверяем, является ли текущий аргумент флагом -i
                if (args[i] == "-n")
                {
                    //Если дальше нет аргументов, выводим ошибку
                    if (i + 1 >= args.Length)
                    {
                        Console.WriteLine("Missing argument!");
                        break;
                    }
                    else
                    {
                        try
                        {

                           n = Int32.Parse(args[i + 1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                }
                if (args[i] == "-m")
                {
                    //Если дальше нет аргументов, выводим ошибку
                    if (i + 1 >= args.Length)
                    {
                        Console.WriteLine("Missing argument!");
                        break;
                    }
                    else
                    {
                        try
                        {
                            m = Int32.Parse(args[i + 1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                }
            }
        }
    }
}
