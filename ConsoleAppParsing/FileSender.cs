using NLog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppParsing
{
    class FileSender
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly HttpResponseMessage _httpResponseMessage = new HttpResponseMessage();
        private readonly HttpClient httpClient = new HttpClient();
        private static string dateGet = DateTime.Now.ToShortDateString();
        public async Task<string> Send(string CSVFilePath, string _webServiceUrl, string _type)
        {
            _logger.Info($"Подключение к веб-сервису.");
            try
            {
                if (_httpResponseMessage.IsSuccessStatusCode)
                {
                    _logger.Info($"Подключение прошло успешно! {_httpResponseMessage.StatusCode}");
                    if (_type == "wb")
                    {
                        using (var formDataFile = new MultipartFormDataContent())
                        using (var fileStream = System.IO.File.OpenRead(CSVFilePath))
                        {
                            formDataFile.Add(new StreamContent(fileStream), "file", $"bonds_{dateGet}.csv");
                            //определение типа и добавление в папку по данному типу
                            formDataFile.Add(new StringContent(_type), "_typeFile");
                            var responseFile = await httpClient.PostAsync(_webServiceUrl, formDataFile);
                            if (responseFile.IsSuccessStatusCode)
                            {
                                _logger.Info("Файл загружен!");
                            }
                            else
                            {
                                _logger.Error($"Файл не удалось загрузить! {responseFile.StatusCode}");
                            }
                        }
                    }
                    else if (_type == "jse")
                    {
                        using (var formDataFile = new MultipartFormDataContent())
                        using (var fileStream = System.IO.File.OpenRead(CSVFilePath))
                        {
                            formDataFile.Add(new StreamContent(fileStream), "file", $"options_{dateGet}.csv");
                            //определение типа и добавление в папку по данному типу
                            formDataFile.Add(new StringContent(_type), "_typeFile");
                            var responseFile = await httpClient.PostAsync(_webServiceUrl, formDataFile);
                            if (responseFile.IsSuccessStatusCode)
                            {
                                _logger.Info("Файл загружен!");
                            }
                            else
                            {
                                _logger.Error($"Файл не удалось загрузить! {responseFile.StatusCode}");
                            }
                        }
                    }
                }
                else
                {
                    _logger.Error($"Подключиться к веб-сервису не удалось! {_httpResponseMessage.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Ошибка: {ex}");
            }
            return null;
        }
    }
}
