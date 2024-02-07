using ConsoleAppParsing.JSE;
using System;
using System.Xml;

namespace ConsoleAppParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            WienerBoerseParser wienerBoerseParser = new WienerBoerseParser();
            JSEParser _parserJSE = new JSEParser();
            _parserJSE.GetOptions();
            wienerBoerseParser.GetBonds();
            Console.WriteLine("Работа завершена успешно, данные получены.");
            Console.ReadKey();
        }
    }

}