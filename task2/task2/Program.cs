namespace task2
{
    struct Point
    {
        public double x;
        public double y;
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //-f1 путь до первого файла -f2 путь до второго файла
            //dotnet run -f1 ./File1.txt -f2 ./File2.txt
            String TextFile1;
            String TextFile2;
            Double Radius;
            List<Point> points = new List<Point>();
            String result = String.Empty;
            ReadArgs(out TextFile1, out TextFile2, args);
            Point CentrCircle = new Point();
            //удаляем лишние пробелы в конце и в начале файла
            TextFile2 = TextFile2.Trim();
            TextFile1 = TextFile1.Trim();
            var digitFile1 = TextFile1.Split(new char[] {' ','\n'}).Select(c=>Double.Parse(c)).ToList();
           
            if (digitFile1.Count != 3)
            {
                Console.WriteLine("Ошибка");
                System.Environment.Exit(1);
            }
            CentrCircle.x = digitFile1[0];
            CentrCircle.y= digitFile1[1];
            Radius = digitFile1[2];
            var digitFile2 = TextFile2.Split(new char[] { ' ', '\n'}).Select(c => Double.Parse(c)).ToList();
            for (int i = 0; i < digitFile2.Count; i += 2)
            {
                points.Add(new Point() { x = digitFile2[i], y = digitFile2[i + 1] });
            }
            foreach (var point in points)
            {
                if (Math.Pow(point.x - CentrCircle.x, 2) + Math.Pow(point.y - CentrCircle.y, 2) > Radius)
                    result += "2\n";
                else if (Math.Pow(point.x - CentrCircle.x, 2) + Math.Pow(point.y - CentrCircle.y, 2) == Radius)
                    result += "0\n";
                else result += "1\n";
            }
            Console.WriteLine("Ответ:\n" + result);

        }
        static void ReadArgs(out String TextFile1, out String TextFile2, string[] args)
        {
            TextFile1 = "";
            TextFile2 = " ";
            for (int i = 0; i < args.Length; i++)
            {
                //Проверяем, является ли текущий аргумент флагом -i
                if (args[i] == "-f1")
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

                            TextFile1 = File.ReadAllText(args[i + 1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                if (args[i] == "-f2")
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
                            TextFile2 = File.ReadAllText(args[i + 1]);
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
