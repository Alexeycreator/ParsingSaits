using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using HtmlAgilityPack;
using System.Linq;
using System.Globalization;
using Microsoft.Extensions.Logging;

namespace ConsoleAppParsing
{
    class WienerBoerseParser
    {
        private readonly string _wienerBoerseUrl;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly HttpResponseMessage _httpResponseMessage = new HttpResponseMessage();
        private readonly string CSVFilePath = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\ConsoleAppParsing\bin\Debug\Bonds.csv";
        public WienerBoerseParser(string url)
        {
            _wienerBoerseUrl = url;
            //_logger = logger;
        }
        public List<Bond> GetBonds()
        {
            return new List<Bond>();
        }
        private string GetPageContent()
        {
            var _httpResponseMessage = _httpClient.GetAsync(_wienerBoerseUrl).Result;
            if (_httpResponseMessage.IsSuccessStatusCode)
            {
                var _htmlResponse = _httpResponseMessage.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(_htmlResponse))
                {
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(_htmlResponse);
                    var container = document.GetElementbyId("c7928-module-container");
                    if (container != null)
                    {
                        var tableBody = document.GetElementbyId("c7928-module-container").ChildNodes.FindFirst("tbody").ChildNodes.Where(x => x.Name == "tr").ToArray();
                        var paginationWienerBoerse = document.DocumentNode.SelectNodes(".//div[@class='panel-footer']");
                        foreach(var tableRow in tableBody)
                        {
                            var _cellName = tableRow.ChildNodes.FindFirst("td").ChildNodes.FindFirst("a").InnerText;
                            var _cellLast = tableRow.SelectSingleNode(".//td[2]").InnerText;
                            var _cellChg = tableRow.SelectSingleNode(".//td[3]").InnerText;
                            var _cellDate = tableRow.SelectSingleNode(".//td[4]").InnerText;
                            var _cellISin = tableRow.SelectSingleNode(".//td[5]").InnerText;
                            var _cellTurnoverVolume = tableRow.SelectSingleNode(".//td[6]").InnerText;
                            var _cellBidVolume = tableRow.SelectSingleNode(".//td[7]").InnerText;
                            var _cellAskVolume = tableRow.SelectSingleNode(".//td[8]").InnerText;
                            var _cellMaturity = tableRow.SelectSingleNode(".//td[9]").InnerText;
                            var _cellStatus = tableRow.SelectSingleNode(".//td[10]").InnerText;
                            NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
                            {
                                NumberDecimalSeparator = ".",
                            };
                            List<Bond> bonds = new List<Bond>();
                            bonds.Add(new Bond
                            {
                                Name = _cellName,
                                Last = double.Parse(_cellLast, numberFormatInfo),
                                Chg = _cellChg,
                                Date = _cellDate,
                                ISin = _cellISin,
                                TurnoverVolume = _cellTurnoverVolume,
                                BidVolume = _cellBidVolume,
                                AskVolume = _cellAskVolume,
                                Maturity = _cellMaturity,
                                Status = _cellStatus
                            });
                        }
                    }
                }
            }
            return null;
        }
        public void GetState()
        {
            GetPageContent();
        }
    }
}
