using Newtonsoft.Json;
using System.Net.Http;
using NLog;
using System;

namespace ConsoleAppParsing.JSE
{
    class JSEParser
    {
        private readonly string _urlJSE = "https://clientportal.jse.co.za/_vti_bin/JSE/DerivativesService.svc/GetTradeOptions";
        private readonly string CSVFilePath = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\ConsoleAppParsing\bin\Debug\Options.csv";
        private readonly Logger _logger;
        private CsvWriter _csvWriter;
        public JSEParser(Logger logger, CsvWriter csvWriter)
        {
            _logger = logger;
            _csvWriter = csvWriter;
        }
        public void Parser()
        {
            HttpClient httpClient = new HttpClient();
            _logger.Info($"Подключение к сайту: {_urlJSE}");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _urlJSE);
            var _resultJSE = httpClient.SendAsync(requestMessage).Result;
            _logger.Info($"Подключение удалось: {_resultJSE.StatusCode}");
            if (_resultJSE.IsSuccessStatusCode)
            {
                var resp = _resultJSE.Content.ReadAsStringAsync().Result;
                _logger.Info("Извлечение данных");
                var result = JsonConvert.DeserializeObject<JSEModel>(resp);
                if (result != null)
                {
                    _logger.Info($"Данные извлечены. Количество {result.StateTablesJSE.Count}");
                    _logger.Info($"Запись в файл по пути {CSVFilePath}");
                    _csvWriter.Write(CSVFilePath, result.StateTablesJSE);
                    _logger.Info($"Данные записаны {result.StateTablesJSE.Count} из {result.StateTablesJSE.Count}");
                }
                else
                {
                    _logger.Error("Данные получить не удалось");
                }
            }
            else
            {
                _logger.Error($"Подключение не удалось! {_resultJSE.StatusCode}");
            }
        }
    }
}

