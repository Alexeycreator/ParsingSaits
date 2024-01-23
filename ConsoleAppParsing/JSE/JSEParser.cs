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
        private static Logger optionsLogger = LogManager.GetCurrentClassLogger();
        private CsvWriter _csvWriter = new CsvWriter();
        public void Parser()
        {
            HttpClient httpClient = new HttpClient();
            optionsLogger.Info($"Подключение к сайту: {_urlJSE}");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _urlJSE);
            var _resultJSE = httpClient.SendAsync(requestMessage).Result;
            optionsLogger.Info($"Подключение удалось: {_resultJSE.StatusCode}");
            if (_resultJSE.IsSuccessStatusCode)
            {
                var resp = _resultJSE.Content.ReadAsStringAsync().Result;
                optionsLogger.Info("Извлечение данных");
                var result = JsonConvert.DeserializeObject<JSEModel>(resp);
                if (result != null)
                {
                    optionsLogger.Info($"Данные извлечены. Количество {result.StateTablesJSE.Count}");
                    optionsLogger.Info($"Запись в файл по пути {CSVFilePath}");
                    _csvWriter.Write(CSVFilePath, result.StateTablesJSE);
                    optionsLogger.Info($"Данные записаны {result.StateTablesJSE.Count} из {result.StateTablesJSE.Count}");
                }
                else
                {
                    optionsLogger.Error("Данные получить не удалось");
                }
            }
            else
            {
                optionsLogger.Error($"Подключение не удалось! {_resultJSE.StatusCode}");
            }
        }
    }
}

