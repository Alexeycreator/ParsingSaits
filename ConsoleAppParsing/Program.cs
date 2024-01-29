using ConsoleAppParsing.JSE;
using System;
using System.Collections.Generic;

namespace ConsoleAppParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            JSEParser _parserJSE = new JSEParser();
            _parserJSE.GetOptions();
            WienerBoerseParser wienerBoerseParser = new WienerBoerseParser();
            wienerBoerseParser.GetBonds();
            Console.WriteLine("Работа завершена успешно, данные получены.");
            Console.ReadKey();
        }
    }

}