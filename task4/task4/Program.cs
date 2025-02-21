namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // параметр -Fp путь до файла
            //dotnet run  -Fp ./TextFile1.txt
            String FilePath;
            ReadArgs(out FilePath,args);
            if (FilePath == " ")
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            try
            {      
                String[] strs = File.ReadAllLines(FilePath);
                int middleDigit=0;
                int result = 0;
                int[] nums = new int[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    nums[i] = int.Parse(strs[i]);
                    middleDigit += nums[i];

                }
                middleDigit/= nums.Length;
                for (int i = 0; i < strs.Length; i++)
                {
                    result +=Math.Abs(nums[i]-middleDigit);

                }
                Console.WriteLine(result);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ReadArgs(out String FilePath, string[] args)
        {
            FilePath = " ";
            for (int i = 0; i < args.Length; i++)
            {
                //Проверяем, является ли текущий аргумент флагом -i
                if (args[i] == "-Fp")
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

                            FilePath = args[i + 1];
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
