using ConsoleAppParsing.JSE;
using ConsoleAppParsing.WienerBoerse;
using NLog;
using System;

namespace ConsoleAppParsing
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            CsvWriter csvWriter = new CsvWriter();
            JSEParser _parserJSE = new JSEParser(logger, csvWriter);
            _parserJSE.Parser();
            SettingsWienerBoerse settingsWienerBoerse = new SettingsWienerBoerse();
            WienerBoerseParser wienerBoerseParser = new WienerBoerseParser(settingsWienerBoerse.urlWienerBoerse, logger, csvWriter);
            wienerBoerseParser.GetBonds();
            Console.ReadKey();
        }
    }

}