//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net;
//using HtmlAgilityPack;
//using System.Linq;
//using System.Globalization;

//namespace ConsoleAppParsing
//{
//    class WienerBoerseParser
//    {
//        private readonly string _wienerBoerseUrl;
//        private readonly object _logger;
//        private readonly HttpClient _httpClient = new HttpClient();

//        public WienerBoerseParser(string url, object logger)
//        {
//            _wienerBoerseUrl = url;
//            _logger = logger;
//        }

//        public List<Bond> GetBonds()
//        {
//            return new List<Bond>();
//        }
//        private string GetPageContent()
//        {
//            _httpClient
//        }
//        public string GetTables(string IdContainer, string tbody, string tr, string td, string a, string pathWienerBoerse)
//        {
            
//            {
//                using(HttpClient client = new HttpClient())
//                {
                    
//                    using (HttpResponseMessage responseMessage = client.GetAsync(url).Result)
//                    {
//                        if (responseMessage.IsSuccessStatusCode)
//                        {
//                            var htmlResponse = responseMessage.Content.ReadAsStringAsync().Result;
//                            if (!string.IsNullOrEmpty(htmlResponse))
//                            {
//                                HtmlDocument document = new HtmlDocument();
//                                document.LoadHtml(htmlResponse);

//                                var container = document.GetElementbyId(IdContainer);

//                                if(container != null)
//                                {
//                                    var tableBody = document.GetElementbyId(IdContainer).ChildNodes.FindFirst(tbody).ChildNodes.Where(x => x.Name == tr).ToArray();
//                                    var paginationSait = document.DocumentNode.SelectNodes(".//div[@class='panel-footer']");
//                                    foreach(var tblRow in tableBody)
//                                    {                              
//                                        //1 столбец
//                                        var field1 = tblRow.ChildNodes.FindFirst(td).ChildNodes.FindFirst(a).InnerText;
//                                        //var tblCells = tblRow.InnerText;

//                                        //Берет всю строку целеком
//                                        //var field2 = tblRow.Descendants("td").Where(node => node.GetAttributeValue("class", "").Contains("")).ToArray();

//                                        //2 столбец
//                                        var field2 = tblRow.SelectSingleNode(".//td[2]").InnerText;
                                        
//                                        //3 столбец
//                                        var field3 = tblRow.SelectSingleNode(".//td[3]").InnerText;

//                                        //4 столбец
//                                        var field4 = tblRow.SelectSingleNode(".//td[4]").InnerText;

//                                        //5 столбец
//                                        var field5 = tblRow.SelectSingleNode(".//td[5]").InnerText;

//                                        //6 столбец
//                                        var field6 = tblRow.SelectSingleNode(".//td[6]").InnerText;

//                                        //7 столбец
//                                        var field7 = tblRow.SelectSingleNode(".//td[7]").InnerText;

//                                        //8 столбец
//                                        var field8 = tblRow.SelectSingleNode(".//td[8]").InnerText;

//                                        //9 столбец
//                                        var field9 = tblRow.SelectSingleNode(".//td[9]").InnerText;

//                                        //10 столбец
//                                        var field10 = tblRow.SelectSingleNode(".//td[10]").InnerText;
//                                        //Console.WriteLine(field1 + " | " +
//                                        //    field2 + " | " +
//                                        //    field3 + " | " +
//                                        //    field4 + " | " +
//                                        //    field5 + " | " +
//                                        //    field6 + " | " +
//                                        //    field7 + " | " +
//                                        //    field8 + " | " +
//                                        //    field9 + " | " +
//                                        //    field10);
//                                        NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
//                                        {
//                                            NumberDecimalSeparator = ".",
//                                        };
//                                        List<WienerBoerseHtml> elemWiener = new List<WienerBoerseHtml>();
//                                        elemWiener.Add(new WienerBoerseHtml
//                                        {
//                                            Name = field1,
//                                            Last = double.Parse(field2, numberFormatInfo),
//                                            Chg = field3,
//                                            //Date = field4,
//                                            ISin = field5,
//                                            TurnoverVolume = field6,
//                                            BidVolume = field7,
//                                            AskVolume = field8,
//                                            //Maturity = field9,
//                                            Status = field10,
//                                        });

//                                        //запись в файл
//                                        //WriteToFile wFile = new WriteToFile();
//                                        //wFile.Filing(pathWienerBoerse, elemWiener);
//                                        foreach (var e in elemWiener)
//                                        {
//                                            Console.WriteLine(e.Name + " | "
//                                                + e.Last + " | "
//                                                + e.Chg + " | "
//                                                + e.ISin + " | "
//                                                + e.TurnoverVolume + " | "
//                                                + e.BidVolume + " | "
//                                                + e.AskVolume + " | "
//                                                + e.Status + " | ");
//                                        }



//                                        //номера страниц приходят
//                                        //foreach(var page in paginationSait)
//                                        //{
//                                        //    var pagin = page.SelectSingleNode(".//li").InnerHtml;

//                                        //    Console.WriteLine(pagin.ToString());
//                                        //}
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            return null;
//        }
//    }
//}
