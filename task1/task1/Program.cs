using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // n - первый параметр m - второй параметр
            int n = Int32.Parse(args[0]);
            int m = Int32.Parse(args[1]); ;
            List<int> Intervals = new List<int>();
            int FirstObjectIndex = 0;
   
            while (FirstObjectIndex != 1)
            {
                if (FirstObjectIndex == 0)
                {
                    Intervals.Add(1);
                    FirstObjectIndex += m;
                }
                else
                    FirstObjectIndex += m - 1;
                if (FirstObjectIndex > n)
                {
                    FirstObjectIndex -= - n;
                }
                Intervals.Add(FirstObjectIndex);
            }
            //при моей реализации в конец всех интервалов добавляется 1 пример 13421 для этого удаляю последний элемент
            Intervals.RemoveAt(Intervals.Count-1);
            foreach (int i in Intervals)
            {
                Console.Write(i);
            }
        }
    }
}
