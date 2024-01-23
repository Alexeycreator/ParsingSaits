using ConsoleAppParsing.JSE;
using ConsoleAppParsing.WienerBoerse;
using NLog;
using System;

namespace ConsoleAppParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            JSEParser _parserJSE = new JSEParser();
            _parserJSE.Parser();
            SettingsWienerBoerse settingsWienerBoerse = new SettingsWienerBoerse();
            WienerBoerseParser wienerBoerseParser = new WienerBoerseParser(settingsWienerBoerse.urlWienerBoerse);
            wienerBoerseParser.GetBonds();
            Console.ReadKey();
        }
    }

}