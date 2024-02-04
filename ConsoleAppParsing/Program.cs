using ConsoleAppParsing.JSE;
using ConsoleAppParsing.ServiseRestApi;
using ConsoleAppParsing.ServiseRestApi.INIFiles;
using ConsoleAppParsing.ServiseRestApi.XmlConfig;
using System;
using System.Xml;

namespace ConsoleAppParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiseHtmlPage serviseHtmlPage = new ServiseHtmlPage();
            WienerBoerseParser wienerBoerseParser = new WienerBoerseParser();
            JSEParser _parserJSE = new JSEParser();
            _ = serviseHtmlPage.StartingSessionAsync();
            _parserJSE.GetOptions();
            wienerBoerseParser.GetBonds();
            XmlSettings xmlSettings = new XmlSettings();
            xmlSettings.Save("jse");
            xmlSettings.GetXML();
            Console.WriteLine("Работа завершена успешно, данные получены.");
            Console.ReadKey();
            serviseHtmlPage.EndingSession();
        }
    }

}