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
            CsvWriter csvWriter = new CsvWriter();
            JSEParser _parserJSE = new JSEParser(loggerOprions, csvWriter);
            _parserJSE.Parser();
            SettingsWienerBoerse settingsWienerBoerse = new SettingsWienerBoerse();
            WienerBoerseParser wienerBoerseParser = new WienerBoerseParser(settingsWienerBoerse.urlWienerBoerse, loggerBonds, csvWriter);
            wienerBoerseParser.GetBonds();
            Console.ReadKey();
        }
    }

}