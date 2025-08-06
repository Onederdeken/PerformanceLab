namespace task2
{
    struct Point
    {
        public double x;
        public double y;
    }
    internal class Program
    {
        
        static void Main()
        {

            //dotnet run C:\Users\Karpacho Kapitovsky\Desktop\PerformanceLab\task2\task2\File1.txt C:\Users\Karpacho Kapitovsky\Desktop\PerformanceLab\task2\task2\File2.txt

            try
            {
                Console.Write("введите полный путь до файла 1: ");
                String PathFile1 = Console.ReadLine();
                String TextFile1 = File.ReadAllText(PathFile1);
                Console.Write("введите полный путь до файла 2: ");
                String PathFile2 = Console.ReadLine();
                String TextFile2 = File.ReadAllText(PathFile2);

                Double Radius;
                List<Point> Points = new List<Point>();
                String Result = String.Empty;
                Point CentrCircle = new Point();
                //удаляем лишние пробелы в конце и в начале файла
                TextFile2 = TextFile2.Trim();
                TextFile1 = TextFile1.Trim();
                //заменяю точки на запятые, что бы считывала дробные цифры
                TextFile2 = TextFile2.Replace(".", ",");
                TextFile1 = TextFile1.Replace(".", ",");

                var DigitFile1 = TextFile1.Split(new char[] { ' ', '\n' }).Select(c => Double.Parse(c)).ToList();

                CentrCircle.x = DigitFile1[0];
                CentrCircle.y = DigitFile1[1];
                Radius = DigitFile1[2];
                var DigitFile2 = TextFile2.Split(new char[] { ' ', '\n' }).Select(c => Double.Parse(c)).ToList();
                for (int i = 0; i < DigitFile2.Count; i += 2)
                {
                    Points.Add(new Point() { x = DigitFile2[i], y = DigitFile2[i + 1] });
                }
                foreach (var point in Points)
                {
                    double formula = Math.Pow(point.x - CentrCircle.x, 2) + Math.Pow(point.y - CentrCircle.y, 2);
                    Console.WriteLine($"x = {point.x}  y={point.y}");
                    Console.WriteLine($"формула: {formula} корень: {Math.Sqrt(formula)}");
                    if (Math.Sqrt(formula) > Radius)
                        Result += "2\n";
                    else if (Math.Sqrt(formula) == Radius)
                        Result += "0\n";
                    else Result += "1\n";
                }
                Console.WriteLine(Result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          

        }
    }
}
