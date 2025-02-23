namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //dotnet run ./TextFile1.txt
            String FilePath = args[0];
            try
            {      
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
                Console.WriteLine(Result);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
