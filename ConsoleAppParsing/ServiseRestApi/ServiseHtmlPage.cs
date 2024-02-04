using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleAppParsing.ServiseRestApi
{
    class ServiseHtmlPage
    {
        HttpListener server = new HttpListener(); 
        private readonly string urlServise = @"http://127.0.0.1:8888/connection/";
        private readonly string xmlFilePath = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\ConsoleAppParsing\ServiseRestApi\XmlConfig\ServiseConfig.xml";
        public async Task StartingSessionAsync()
        {
            Console.WriteLine($"Веб-сервер запущен по адресу: {urlServise}");
            server.Prefixes.Add(urlServise);
            //запуск веб-сервиса
            server.Start();
            await ServiseContentAsync();
        }
        private async Task ServiseContentAsync()
        {
            // получаем контекст
            var context = await server.GetContextAsync();
            var response = context.Response;
            string responseText =
                @$"<!DOCTYPE html>
                <html>
                    <head>
                        <meta charset='utf8'>
                        <title>RestApi Servise</title>
                    </head>
                    <body>
                        <h1>Hello</h1>
                        <button>Список файлов</button>
                        <button>Загрузить файл</button>
                    </body>
                </html>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseText);
            // получаем поток ответа и пишем в него ответ
            response.ContentLength64 = buffer.Length;
            using Stream output = response.OutputStream;
            // отправляем данные
            await output.WriteAsync(buffer);
            await output.FlushAsync();
        }
        private string Save()
        {
            return null;
        }
        private string List()
        {
            return null;
        }
        private string Load()
        {
            return null;
        }
        public void EndingSession()
        {
            //остановка и закрытие
            server.Stop();
            server.Close();
        }
    }
}
