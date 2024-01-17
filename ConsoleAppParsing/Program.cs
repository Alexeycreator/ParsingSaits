using ConsoleAppParsing.WienerBoerse;
using HtmlAgilityPack;
using System;
using System.Net;
using System.Net.Http;

namespace ConsoleAppParsing
{
    class Program
    {
        static void Main(string[] args)
        {

            string urlJSE2 = "https://clientportal.jse.co.za/_vti_bin/JSE/DerivativesService.svc/GetTradeOptions";

            string urlJSE1 = "/_vti_bin/JSE/DerivativesService.svc/GetTradeOptions";

            GetTablesHtml getTables = new GetTablesHtml();

            GetTablesSettingsWienerBoerse settingsWienerBoerse = new GetTablesSettingsWienerBoerse();

            getTables.GetTables(
                settingsWienerBoerse.urlWienerBoerse,
                settingsWienerBoerse.IdContainer,
                settingsWienerBoerse.tbody,
                settingsWienerBoerse.tr,
                settingsWienerBoerse.td,
                settingsWienerBoerse.a,
                settingsWienerBoerse.pathWienerBoerse
                );

            Console.ReadKey();
        }
    }
}




//foreach (var tCells in tblCells)
//{

//    var field2 = tCells.InnerText;

//    //foreach(var tblCell in tblCells)
//    //{
//    //    var field2 = tblCell.InnerText;
//    //    List<WienerBoerseHtml> elem1 = new List<WienerBoerseHtml>();
//    //    elem1.Add(new WienerBoerseHtml
//    //    {
//    //        Name = field1,
//    //        ISin = field2,
//    //    });
//    //    foreach(var e2 in elem1)
//    //    {
//    //        Console.WriteLine(e2.Name + " | " + e2.ISin + " | ");
//    //    }
//    //}

//}


/*
 try
            {
                JSEWebsiteHtml jSE = new JSEWebsiteHtml();
                string url1 = jSE.urlJSEWebsite;
                using (HttpClientHandler handler = new HttpClientHandler
                {
                    AllowAutoRedirect = false,
                    AutomaticDecompression = DecompressionMethods.Deflate |
                    DecompressionMethods.GZip |
                    DecompressionMethods.None
                })
                {
                    using (HttpClient httpClient = new HttpClient(handler))
                    {
                        using (HttpResponseMessage responseMessage = httpClient.GetAsync(url1).Result)
                        {
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                var htmlResponse = responseMessage.Content.ReadAsStringAsync().Result;
                                if (!string.IsNullOrEmpty(htmlResponse))
                                {
                                    //Console.WriteLine("Успешно!");
                                    //использование библиотеки htmlAgillityPack
                                    HtmlDocument document = new HtmlDocument();
                                    document.LoadHtml(htmlResponse);

                                    //получение таблицы
                                    var tables = document.DocumentNode.SelectNodes(".//div[@class='row']//div[@class='col-lg-12 col-md-12 col-sm-12 col-sx-12']//div[@class='table-responsive']");

                                    //проверка на то, что таблица получена
                                    if (tables != null && tables.Count > 0)
                                    {
                                        //Console.WriteLine("Таблица получена!");

                                        foreach (var table in tables)
                                        {
                                            var titleTable = document.DocumentNode.SelectNodes(".//div[@class='titlePage']");

                                            if(titleTable != null)
                                            {
                                                List<JSEWebsiteHtml> elem = new List<JSEWebsiteHtml>();
                                                for(int i = 0; i < titleTable.Count; i++)
                                                {
                                                    elem.Add(new JSEWebsiteHtml
                                                    {
                                                        Title = titleTable[i].InnerText.Trim()
                                                    });
                                                }
                                                foreach(JSEWebsiteHtml item in elem)
                                                {
                                                    Console.WriteLine(item.Title);
                                                }
                                                var rowsTables = document.DocumentNode.SelectNodes(".//table[@class='table tradeOptionsTable']");

                                                if(rowsTables != null)
                                                {
                                                    var rowsTablesBody = table.SelectNodes(".//tr");
                                                    //Console.WriteLine("RowsTables");
                                                    if(rowsTablesBody != null)
                                                    {
                                                        //Console.WriteLine("rowsTablesBody");
                                                        List<JSEWebsiteHtml> elemRowsBody = new List<JSEWebsiteHtml>();
                                                        for (int i = 0; i < rowsTablesBody.Count; i++)
                                                        {
                                                            elemRowsBody.Add(new JSEWebsiteHtml
                                                            {
                                                                RowsTables = rowsTablesBody[i].InnerText.Trim()
                                                            });
                                                        }
                                                        foreach(JSEWebsiteHtml elemRowsB in elemRowsBody)
                                                        {
                                                            Console.WriteLine(elemRowsB.RowsTables.ToString());
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("not yes");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Не получилось!");
                                                }
                                            }

                                            else
                                            {
                                                Console.WriteLine("Не удалось получить заголовок.");
                                            }
                                        }
                                    }
                                    else Console.WriteLine("Таблицу не удалось получить!");
                                    
                                }
                                else Console.WriteLine("Не удалось подключиться.");
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
 */







////заполнение коллекции заголовков столбцов таблицы
//List<JSEWebsiteHtml> elemTableCellsTitle = new List<JSEWebsiteHtml>();
//for(int i = 0; i <= titleTableCells.Count; i++)
//{
//    elemTableCellsTitle.Add(new JSEWebsiteHtml
//    {
//        TradeDate = DateTime.Parse(titleTableCells[i].InnerText),
//        TradeType = titleTableCells[i + 1].InnerText.Trim(),
//        ShortName = titleTableCells[i + 2].InnerText.Trim(),
//        FutureExpiry = titleTableCells[i + 3].InnerText.Trim(),
//        Strike = int.Parse(titleTableCells[i + 4].InnerText),
//        Call_Put = titleTableCells[i + 5].InnerText.Trim(),
//        Quantity = int.Parse(titleTableCells[i + 6].InnerText),
//        Vol = double.Parse(titleTableCells[i + 7].InnerText),
//        Premium = int.Parse(titleTableCells[i + 8].InnerText),
//        Futures_Price = double.Parse(titleTableCells[i + 9].InnerText)
//    });
//}

//вывод названия заголовков таблицы
//foreach (JSEWebsiteHtml itemCellsTitle in elemTableCellsTitle)
//{
//    Console.WriteLine(string.Join("\t", 
//        itemCellsTitle.TradeDate,
//        itemCellsTitle.TradeType,
//        itemCellsTitle.ShortName,
//        itemCellsTitle.FutureExpiry,
//        itemCellsTitle.Strike,
//        itemCellsTitle.Call_Put,
//        itemCellsTitle.Quantity,
//        itemCellsTitle.Vol,
//        itemCellsTitle.Premium,
//        itemCellsTitle.Futures_Price
//        ));
//}




////проверка на заголовок
//if (titleTable != null)
//{
//    //для добавления полученных значений в коллекцию
//    List<JSEWebsiteHtml> elem = new List<JSEWebsiteHtml>();
//    for (int i = 0; i < titleTable.Count; i++)
//    {
//        elem.Add(new JSEWebsiteHtml
//        {
//            Title = titleTable[i].InnerText.Trim()
//        });
//    }
//    //для вывода названия таблицы
//    foreach (JSEWebsiteHtml item in elem)
//    {
//        Console.WriteLine(string.Join(Environment.NewLine, item.Title));
//    }

//    //для заголовков столбцов таблицы
//    var titleTableCells = document.DocumentNode.SelectNodes(".//div[@class='table-responsive']//table");

//    //проверка, что у столбцов таблицы есть названия
//    if (titleTableCells != null)
//    {
//        List<JSEWebsiteHtml> elemTitleTableCells = new List<JSEWebsiteHtml>();
//        for (int i = 0; i < titleTableCells.Count; i++)
//        {
//            elemTitleTableCells.Add(new JSEWebsiteHtml
//            {
//                TitleCellsTable = titleTableCells[i].InnerText.Trim()
//            });
//        }

//        foreach (JSEWebsiteHtml itemTitleCells in elemTitleTableCells)
//        {
//            Console.WriteLine(itemTitleCells.TitleCellsTable);
//        }

//        var rowsTables = document.DocumentNode.SelectNodes(".//tr");
//        if (rowsTables != null)
//        {
//            Console.WriteLine("Ok. RowsTables.");

//            List<JSEWebsiteHtml> elem3 = new List<JSEWebsiteHtml>();
//            for (int i = 0; i < rowsTables.Count; i++)
//            {
//                elem3.Add(new JSEWebsiteHtml
//                {
//                    RowsTables = rowsTables[i].InnerText.Trim()
//                });
//            }

//            foreach (JSEWebsiteHtml item2 in elem3)
//            {
//                Console.WriteLine(item2.RowsTables);
//            }

//            foreach (var row in rowsTables)
//            {
//                var cellsTables = row.SelectNodes(".//td");
//                if (cellsTables != null)
//                {
//                    Console.WriteLine("Ok. CellsRows");
//                }
//                else
//                {
//                    Console.WriteLine("no. cellsRows");
//                }
//            }
//        }
//        else
//        {
//            Console.WriteLine("no. rowsTables");
//        }
//    }
//    else
//    {
//        Console.WriteLine("У таблицы нет названия столбцов.");
//    }
//}





//    private static Dictionary<string, List<List<string>>> Parsing(string url)
//    {
//        try
//        {
//            Dictionary<string, List<List<string>>> result = new Dictionary<string, List<List<string>>>();
//            using (HttpClientHandler handler = new HttpClientHandler { AllowAutoRedirect = false, 
//                AutomaticDecompression = System.Net.DecompressionMethods.Deflate | 
//                System.Net.DecompressionMethods.GZip | 
//                System.Net.DecompressionMethods.None })
//            {
//                using (var client = new HttpClient(handler))
//                {
//                    using (HttpResponseMessage response = client.GetAsync(url).Result)
//                    {
//                        if (response.IsSuccessStatusCode)
//                        {
//                            var htmlResponse = response.Content.ReadAsStringAsync().Result;
//                            if (!string.IsNullOrEmpty(htmlResponse))
//                            {
//                                //использование библиотеки
//                                HtmlDocument document = new HtmlDocument();
//                                document.LoadHtml(htmlResponse);

//                                //указываем путь к таблице
//                                var tables = document.DocumentNode.SelectNodes("//*[@id=\"c7928-module-container\"]");

//                                //проверка на то, что таблицу получили
//                                if(tables != null && tables.Count > 0)
//                                {
//                                    foreach(var table in tables)
//                                    {
//                                        //для заголовков таблиц
//                                        var title1 = table.SelectSingleNode("//*[@id=\"tablesaw-954\"]/thead");
//                                        if(title1 != null)
//                                        {
//                                            //для значения в таблице
//                                            var bodyTable = table.SelectSingleNode("//*[@id=\"tablesaw-954\"]/tbody");
//                                            if(bodyTable != null)
//                                            {
//                                                //строки в таблице
//                                                var rows = table.SelectNodes("//*[@id=\"tablesaw-954\"]/tbody/tr[1]");
//                                                if(rows != null && rows.Count > 0)
//                                                {
//                                                    var res = new List<List<string>>();

//                                                    foreach(var row in rows)
//                                                    {
//                                                        //колонки в таблице
//                                                        var cells = row.SelectNodes("//*[@id=\"tablesaw-954\"]/tbody/tr[1]/td[1]");
//                                                        if(cells != null && cells.Count > 0)
//                                                        {
//                                                            res.Add(new List<string>(cells.Select(c => c.InnerText)));
//                                                        }
//                                                    }
//                                                    result[title1.InnerText] = res;
//                                                }
//                                            }
//                                        }
//                                    }
//                                    return result;
//                                }
//                                else
//                                {
//                                    Console.WriteLine("no tables");
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        }
//        catch(Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }

//        return null;
//    }



