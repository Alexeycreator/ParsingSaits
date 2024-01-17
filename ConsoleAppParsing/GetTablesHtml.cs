using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using HtmlAgilityPack;
using System.Linq;

namespace ConsoleAppParsing
{
    class GetTablesHtml
    {
        public string GetTables(string url, string IdContainer, string tbody, string tr, string td, string a)
        {
            using (HttpClientHandler handler = new HttpClientHandler { 
                AllowAutoRedirect=false,
                AutomaticDecompression = DecompressionMethods.GZip |
                DecompressionMethods.Deflate |
                DecompressionMethods.None
            })
            {
                using(HttpClient client = new HttpClient(handler))
                {
                    using (HttpResponseMessage responseMessage = client.GetAsync(url).Result)
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            var htmlResponse = responseMessage.Content.ReadAsStringAsync().Result;
                            if (!string.IsNullOrEmpty(htmlResponse))
                            {
                                HtmlDocument document = new HtmlDocument();
                                document.LoadHtml(htmlResponse);

                                var container = document.GetElementbyId(IdContainer);

                                if(container != null)
                                {
                                    var tableBody = document.GetElementbyId(IdContainer).ChildNodes.FindFirst(tbody).ChildNodes.Where(x => x.Name == tr).ToArray();
                                    foreach(var tblRow in tableBody)
                                    {
                                                                               
                                        //1 столбец
                                        var field1 = tblRow.ChildNodes.FindFirst(td).ChildNodes.FindFirst(a).InnerText;
                                        //var tblCells = tblRow.InnerText;

                                        //2 столбец
                                        //Берет всю строку целеком
                                        //var field2 = tblRow.Descendants("td").Where(node => node.GetAttributeValue("class", "").Contains("")).ToArray();
                                        var field2 = tblRow.SelectSingleNode(".//td[2]").InnerText;
                                        
                                        //3 столбец
                                        var field3 = tblRow.SelectSingleNode(".//td[3]").InnerText;

                                        //4 столбец
                                        var field4 = tblRow.SelectSingleNode(".//td[4]").InnerText;

                                        //5 столбец
                                        var field5 = tblRow.SelectSingleNode(".//td[5]").InnerText;

                                        //6 столбец
                                        var field6 = tblRow.SelectSingleNode(".//td[6]").InnerText;

                                        //7 столбец
                                        var field7 = tblRow.SelectSingleNode(".//td[7]").InnerText;

                                        //8 столбец
                                        var field8 = tblRow.SelectSingleNode(".//td[8]").InnerText;

                                        //9 столбец
                                        var field9 = tblRow.SelectSingleNode(".//td[9]").InnerText;

                                        //10 столбец
                                        var field10 = tblRow.SelectSingleNode(".//td[10]").InnerText;
                                        Console.WriteLine(field1 + " | " +
                                            field2 + " | " +
                                            field3 + " | " +
                                            field4 + " | " +
                                            field5 + " | " +
                                            field6 + " | " +
                                            field7 + " | " +
                                            field8 + " | " +
                                            field9 + " | " +
                                            field10);

                                        List<WienerBoerseHtml> elemWiener = new List<WienerBoerseHtml>();
                                        elemWiener.Add(new WienerBoerseHtml
                                        {
                                            Name = field1,
                                            //ISin = tblCells.ToString(),
                                            ISin = field2.ToString(),

                                            //Chg = field3,
                                            Status = field10,
                                        });
                                        foreach (var e in elemWiener)
                                        {
                                            Console.WriteLine(e.Name + " | " + e.ISin + " | " + e.Status);
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
