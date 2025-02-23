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
            
            //dotnet run ./File1.txt ./File2.txt
            String TextFile1 = File.ReadAllText(args[0]);
            String TextFile2 = File.ReadAllText(args[1]);
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

            var DigitFile1 = TextFile1.Split(new char[] {' ','\n'}).Select(c=>Double.Parse(c)).ToList();
          
            CentrCircle.x = DigitFile1[0];
            CentrCircle.y= DigitFile1[1];
            Radius = DigitFile1[2];
            var DigitFile2 = TextFile2.Split(new char[] { ' ', '\n'}).Select(c => Double.Parse(c)).ToList();
            for (int i = 0; i < DigitFile2.Count; i += 2)
            {
                Points.Add(new Point() { x = DigitFile2[i], y = DigitFile2[i + 1] });
            }
            foreach (var point in Points)
            {
                if (Math.Pow(point.x - CentrCircle.x, 2) + Math.Pow(point.y - CentrCircle.y, 2) > Radius)
                    Result += "2\n";
                else if (Math.Pow(point.x - CentrCircle.x, 2) + Math.Pow(point.y - CentrCircle.y, 2) == Radius)
                    Result += "0\n";
                else Result += "1\n";
            }
            Console.WriteLine(Result);

        }
    }
}
