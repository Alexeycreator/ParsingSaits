using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ConsoleAppParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Адрес, который нам нужен
            Dictionary<string, List<List<string>>> result = Parsing(url: "https://www.wienerborse.at/en/bonds/?c7928-page=2&per-page=50&cHash=ee36cc2f1ce3bd58128f6364139c8e3d");
            if (result != null)
            {
                foreach(var item in result)
                {
                    Console.WriteLine(item.Key);
                    Console.WriteLine("---------------------------");
                    Console.WriteLine(item.Key);
                    Console.WriteLine("---------------------------");
                    item.Value.ForEach(r => Console.WriteLine(string.Join("\t", r)));
                    Console.WriteLine("--------------------------\n");
                }
            }
            Console.WriteLine("Нажмите любую клавишу, чтобы выйти из программы.");
            Console.ReadKey();
        }

        private static Dictionary<string, List<List<string>>> Parsing(string url)
        {
            try
            {
                Dictionary<string, List<List<string>>> result = new Dictionary<string, List<List<string>>>();
                using (HttpClientHandler handler = new HttpClientHandler { AllowAutoRedirect = false, 
                    AutomaticDecompression = System.Net.DecompressionMethods.Deflate | 
                    System.Net.DecompressionMethods.GZip | 
                    System.Net.DecompressionMethods.None })
                {
                    using (var client = new HttpClient(handler))
                    {
                        using (HttpResponseMessage response = client.GetAsync(url).Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var htmlResponse = response.Content.ReadAsStringAsync().Result;
                                if (!string.IsNullOrEmpty(htmlResponse))
                                {
                                    //использование библиотеки
                                    HtmlDocument document = new HtmlDocument();
                                    document.LoadHtml(htmlResponse);

                                    //указываем путь к таблице
                                    var tables = document.DocumentNode.SelectNodes("//*[@id=\"c7928-module-container\"]");

                                    //проверка на то, что таблицу получили
                                    if(tables != null && tables.Count > 0)
                                    {
                                        foreach(var table in tables)
                                        {
                                            //для заголовков таблиц
                                            var title1 = table.SelectSingleNode("//*[@id=\"tablesaw-954\"]/thead");
                                            if(title1 != null)
                                            {
                                                //для значения в таблице
                                                var bodyTable = table.SelectSingleNode("//*[@id=\"tablesaw-954\"]/tbody");
                                                if(bodyTable != null)
                                                {
                                                    //строки в таблице
                                                    var rows = table.SelectNodes("//*[@id=\"tablesaw-954\"]/tbody/tr[1]");
                                                    if(rows != null && rows.Count > 0)
                                                    {
                                                        var res = new List<List<string>>();

                                                        foreach(var row in rows)
                                                        {
                                                            //колонки в таблице
                                                            var cells = row.SelectNodes("//*[@id=\"tablesaw-954\"]/tbody/tr[1]/td[1]");
                                                            if(cells != null && cells.Count > 0)
                                                            {
                                                                res.Add(new List<string>(cells.Select(c => c.InnerText)));
                                                            }
                                                        }
                                                        result[title1.InnerText] = res;
                                                    }
                                                }
                                            }
                                        }
                                        return result;
                                    }
                                    else
                                    {
                                        Console.WriteLine("no tables");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
