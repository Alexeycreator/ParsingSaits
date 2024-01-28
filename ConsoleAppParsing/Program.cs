using ConsoleAppParsing.JSE;
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
            WienerBoerseParser wienerBoerseParser = new WienerBoerseParser();
            wienerBoerseParser.GetPageContent();
            Console.WriteLine("Работа завершена успешно, данные получены.");
            Console.ReadKey();
        }
    }

}