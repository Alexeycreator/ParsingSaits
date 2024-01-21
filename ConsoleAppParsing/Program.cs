using ConsoleAppParsing.JSE;
using ConsoleAppParsing.WienerBoerse;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleAppParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Debug));
            var loggerOprions = loggerFactory.CreateLogger<JSEParser>();
            var loggerBonds = loggerFactory.CreateLogger<WienerBoerseParser>();
            JSEParser _parserJSE = new JSEParser(loggerOprions);
            _parserJSE.Parser();
            SettingsWienerBoerse settingsWienerBoerse = new SettingsWienerBoerse();
            WienerBoerseParser wienerBoerseParser = new WienerBoerseParser(settingsWienerBoerse.urlWienerBoerse, loggerBonds);
            wienerBoerseParser.GetBonds();
            Console.ReadKey();
        }
    }

}