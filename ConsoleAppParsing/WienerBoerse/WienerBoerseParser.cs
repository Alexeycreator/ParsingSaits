using System.Collections.Generic;
using System.Net.Http;
using HtmlAgilityPack;
using System.Linq;
using System;
using NLog;

namespace ConsoleAppParsing
{
    class WienerBoerseParser
    {
        private readonly string _wienerBoerseUrl;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly HttpResponseMessage _httpResponseMessage = new HttpResponseMessage();
        private readonly Logger _logger;
        private readonly string CSVFilePath = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\ConsoleAppParsing\bin\Debug\Bonds.csv";
        private CsvWriter _csvWriter;
        public WienerBoerseParser(string url, Logger logger, CsvWriter csvWriter)
        {
            _wienerBoerseUrl = url;
            _logger = logger;
            _csvWriter = csvWriter;
        }
        public List<Bond> GetBonds()
        {
            GetPageContent();
            return new List<Bond>();
        }
        private string GetPageContent()
        {
            _logger.Info($"Подключение к сайту по адресу: {_wienerBoerseUrl}");
            var _httpResponseMessage = _httpClient.GetAsync(_wienerBoerseUrl).Result;
            if (_httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.Info($"Подключение прошло успешно. {_httpResponseMessage.StatusCode}");
                var _htmlResponse = _httpResponseMessage.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(_htmlResponse))
                {
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(_htmlResponse);
                    var container = document.GetElementbyId("c7928-module-container");
                    if (container != null)
                    {
                        _logger.Info("Контент страницы получен");
                        var tableBody = document.GetElementbyId("c7928-module-container").ChildNodes.FindFirst("tbody").ChildNodes.Where(x => x.Name == "tr").ToArray();
                        var paginationWienerBoerse = document.DocumentNode.SelectNodes(".//div[@class='pull-right']");
                        List<Bond> bonds = new List<Bond>();
                        _logger.Info("Извлечение данных.");
                        foreach (var tableRow in tableBody)
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
                            bonds.Add(new Bond
                            {
                                Name = _cellName,
                                Last = _cellLast,
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
                        if (bonds != null)
                        {
                            _logger.Info($"Данные со страницы извлечены. Количество: {bonds.Count}");
                            _logger.Info($"Идет запись в файл по пути: {CSVFilePath}");
                            _csvWriter.Write(CSVFilePath, bonds);
                            _logger.Info($"Данные записаны в файл. Количество {bonds.Count} из {bonds.Count}");
                        }
                        else 
                        {
                            _logger.Error("Данные не удалось извлечь и записать в файл");
                        }
                    }
                }
            }
            else 
            {
                _logger.Error($"Подключиться не удалось. {_httpResponseMessage.StatusCode}");
            }
            return null;
        }
    }
}
