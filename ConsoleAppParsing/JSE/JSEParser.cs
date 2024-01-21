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
            _logger.LogInformation("Подключение к сайту JSE");
            if (_resultJSE.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Удалось подключиться по адресу: {_urlJSE}");
                var resp = _resultJSE.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<JSEModel>(resp);
                if (result != null)
                {
                    _logger.LogInformation("Данные получены.");
                    CsvWriter csvWriter = new CsvWriter();
                    csvWriter.Write(CSVFilePath, result.StateTablesJSE);
                    bool flag = true;
                    if(flag == true)
                    {
                        _logger.LogInformation($"Данные записаны в файл, по указанному пути: {CSVFilePath}");
                    }
                    else
                    {
                        _logger.LogError("Ошибка");
                        _logger.LogInformation($"Данные не удалось записать в указанный путь: {CSVFilePath}, проверьте путь.");
                    }
                }
                else
                {
                    _logger.LogError("Ошибка");
                    _logger.LogInformation($"Данные с сайта {_urlJSE} не удалось загрузить.");
                }
            }
            else
            {
                _logger.LogError("Ошибка");
            }
        }
    }
}

