using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ConsoleAppParsing.JSE
{
    class JSEParser
    {
        private readonly string _urlJSE = "https://clientportal.jse.co.za/_vti_bin/JSE/DerivativesService.svc/GetTradeOptions";
        private readonly string CSVFilePath = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\ConsoleAppParsing\bin\Debug\Options.csv";
        private readonly ILogger _logger;
        public JSEParser(ILogger<JSEParser> logger)
        {
            _logger = logger;
        }
        public void Parser()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _urlJSE);
            var _resultJSE = httpClient.SendAsync(requestMessage).Result;
            if (_resultJSE.IsSuccessStatusCode)
            {
                var resp = _resultJSE.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<JSEModel>(resp);
                if (result != null)
                {
                    CsvWriter csvWriter = new CsvWriter();
                    csvWriter.Write(CSVFilePath, result.StateTablesJSE);
                    _logger.LogInformation($"{_urlJSE}\n{result.StateTablesJSE}");
                }
                else
                {
                    Console.WriteLine("Данные с сайта JSE не удалось загрузить.");
                }
            }
        }
    }
}

