using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task3
{ 
    internal class Program
    {
        //кот
        static void Main(string[] args)
        {
            //Запуск программы с аргументами
            //dotnet run -ValuePath .\values-c44d5c50d1.json -TestPath .\tests-edf09d69ff.json -ReportPath .\report.json
            // -ValuePath путь до файла values.json
            // -TestPath путь до файла tests.json
            //  -ReportPath путь до файла report.json
            System.String ValueFilePath =" ";
            System.String TestFilePath = " ";
            System.String ReportPath=" ";
            
            ReadArgs(out ValueFilePath, out TestFilePath, out ReportPath,args);
            // Загрузка данных из файлов
            var testsData = LoadJson(TestFilePath);
            var valuesData = LoadJson(ValueFilePath);

            // Создание словаря для быстрого поиска значений по id
            var valuesDict = new Dictionary<int, string>();
            foreach (var value in valuesData["values"])
            {
                valuesDict[value["id"].ToObject<int>()] = value["value"].ToString();
            }

            // Заполнение значений в структуре tests
            FillValues(testsData["tests"], valuesDict);

            // Сохранение результата в report.json
            using (var writer = new StreamWriter(ReportPath))
            {
                writer.Write(testsData.ToString((Newtonsoft.Json.Formatting)Formatting.Indented));
            }
        }

        static JObject LoadJson(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                return JObject.Parse(reader.ReadToEnd());
            }
        }
        static void FillValues(JToken tests, Dictionary<int, string> valuesDict)
        {
            foreach (var test in tests)
            {
                if (test["id"] != null && valuesDict.ContainsKey(test["id"].ToObject<int>()))
                {
                    test["value"] = valuesDict[test["id"].ToObject<int>()];
                }

                if (test["values"] != null)
                {
                    FillValues(test["values"], valuesDict);
                }
            }
        }
        static void ReadArgs(out System.String Value, out System.String Test, out System.String ReportPath, string[] args)
        {
            Value = "";
            Test = " ";
            ReportPath = " ";
            for (int i = 0; i < args.Length; i++)
            {
                //Проверяем, является ли текущий аргумент флагом -i
                if (args[i] == "-ValuePath")
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
                            
                            Value = args[i + 1];
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);  
                        }
                       
                       

                    }
                }
                if (args[i] == "-TestPath")
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
                            Test = args[i + 1];
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                }
                if (args[i] == "-ReportPath")
                {
                    //Если дальше нет аргументов, выводим ошибку
                    if (i + 1 >= args.Length)
                    {
                        Console.WriteLine("Missing argument!");
                        break;
                    }
                    else
                    {
                        ReportPath = args[i + 1];
                    }
                }
            }
        }
            
    }
}
