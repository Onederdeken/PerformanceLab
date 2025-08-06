namespace task4
{
    internal class Program
    {
        static void Main()
        {

            //dotnet run C:\Users\Karpacho Kapitovsky\Desktop\PerformanceLab\task4\task4\TextFile1.txt 
            try
            {
                Console.Write("Путь до файла: ");
                String FilePath = Console.ReadLine();
                String[] Strs = File.ReadAllLines(FilePath);
                List<int> Nums = new List<int>();
                foreach (var item in Strs)
                {
                    Nums.Add(Int32.Parse(item));
                }
                int MiddleDigit=0;
                int Result = 0;
                //сортируем массив и находим середину массива
                Nums.Sort();
                MiddleDigit = Nums[Nums.Count / 2];
                for (int i = 0; i < Strs.Length; i++)
                {
                    Result +=Math.Abs(Nums[i]-MiddleDigit);
                }
                Console.WriteLine($"Минимальное количество ходов:{Result}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
