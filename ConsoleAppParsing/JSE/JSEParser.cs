using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ConsoleAppParsing.JSE
{
    class JSEParser
    {
        private string _urlJSE = "https://clientportal.jse.co.za/_vti_bin/JSE/DerivativesService.svc/GetTradeOptions";
        public void Parser()
        {
            HttpClient httpClient = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _urlJSE);

            var _resultJSE = httpClient.SendAsync(requestMessage).Result;

            if (_resultJSE.IsSuccessStatusCode)
            {
                var resp = _resultJSE.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<JSEModel>(resp);
                foreach (var item in result.StateTablesJSE)
                {
                    Console.WriteLine(item.TradeDate + " | "
                        + item.TradeType + " | "
                        + item.ShortName + " | "
                        + item.FutureExpiry + " | "
                        + item.Strike + " | "
                        + item.CallPut + " | "
                        + item.Quantity + " | "
                        + item.Vol + " | "
                        + item.Premium + " | "
                        + item.FuturesPrice
                        );
                }
            }
        }
    }
}
