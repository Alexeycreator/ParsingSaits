using Newtonsoft.Json;
using System.Net.Http;
using NLog;
using System;

namespace ConsoleAppParsing.JSE
{
    class JSEParser
    {
        private readonly string _urlJSE = "https://clientportal.jse.co.za/_vti_bin/JSE/DerivativesService.svc/GetTradeOptions";
        private static string dateGetOptions = DateTime.Now.ToShortDateString();
        private readonly string CSVFilePath = $@"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\ConsoleAppParsing\bin\Debug\parsingOptions\Options_{dateGetOptions}.csv";
        private static Logger optionsLogger = LogManager.GetCurrentClassLogger();
        private CsvWriter _csvWriter = new CsvWriter();
        public string GetOptions()
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
                    if (result.StateTablesJSE != null)
                    {
                        optionsLogger.Info($"Данные извлечены. Количество {result.StateTablesJSE.Count}");
                        if(result.StateTablesJSE.Count != 0)
                        {
                            optionsLogger.Info($"Запись в файл по пути {CSVFilePath}");
                            _csvWriter.Write(CSVFilePath, result.StateTablesJSE);
                            optionsLogger.Info($"Данные записаны {result.StateTablesJSE.Count} из {result.StateTablesJSE.Count}");
                        }
                        else
                        {
                            optionsLogger.Info($"Количество данных на сайте {result.StateTablesJSE.Count}, запись в файл не требуется.");
                        }
                    }
                    else
                    {
                        optionsLogger.Error($"Данных на сайте нет");
                    }
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
            return null;
        }
    }
}

