using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ConsoleAppParsing.JSE
{
    class JSEParser
    {
        private readonly string _urlJSE = "https://clientportal.jse.co.za/_vti_bin/JSE/DerivativesService.svc/GetTradeOptions";
        private readonly string pathFileCSV = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\ConsoleAppParsing\bin\Debug\Options.csv";
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
                    csvWriter.Write(pathFileCSV, result.StateTablesJSE);
                    Console.WriteLine("Данные с сайта JSE успешно загружены.");
                }
                else
                {
                    Console.WriteLine("Данные с сайта JSE не удалось загрузить.");
                }
            }
        }
    }
}

