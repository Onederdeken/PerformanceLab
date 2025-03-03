﻿using Newtonsoft.Json;
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
            //dotnet run  .\values-c44d5c50d1.json  .\tests-edf09d69ff.json  .\report.json
            //values.json первый аргумент tests.json второй агрумент report.json третий аргумент
            System.String ValueFilePath = args[0];
            System.String TestFilePath = args[1];
            System.String ReportPath= args[2];
            // Загрузка данных из файлов
            var TestsData = LoadJson(TestFilePath);
            var ValuesData = LoadJson(ValueFilePath);

            // Создание словаря для быстрого поиска значений по id
            var ValuesDict = new Dictionary<int, string>();
            foreach (var value in ValuesData["values"])
            {
                ValuesDict[value["id"].ToObject<int>()] = value["value"].ToString();
            }

            // Заполнение значений в структуре tests
            FillValues(TestsData["tests"], ValuesDict);

            // Сохранение результата в report.json
            using (var writer = new StreamWriter(ReportPath))
            {
                writer.Write(TestsData.ToString((Newtonsoft.Json.Formatting)Formatting.Indented));
            }
        }

        static JObject LoadJson(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                return JObject.Parse(reader.ReadToEnd());
            }
        }
        static void FillValues(JToken tests, Dictionary<int, string> ValuesDict)
        {
            foreach (var test in tests)
            {
                if (test["id"] != null && ValuesDict.ContainsKey(test["id"].ToObject<int>()))
                {
                    test["value"] = ValuesDict[test["id"].ToObject<int>()];
                }

                if (test["values"] != null)
                {
                    FillValues(test["values"], ValuesDict);
                }
            }
        }
    }
}
