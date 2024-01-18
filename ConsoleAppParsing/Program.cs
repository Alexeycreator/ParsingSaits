using ConsoleAppParsing.WienerBoerse;
using HtmlAgilityPack;
using System;
using System.Net;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using ConsoleAppParsing.JSE;
using System.Collections.Generic;

namespace ConsoleAppParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            JSEParser _parserJSE = new JSEParser();
            _parserJSE.Parser();

            Console.ReadKey();
        }
    }
}





//GetTablesSettingsWienerBoerse settingsWienerBoerse = new GetTablesSettingsWienerBoerse();
//var wienerBoerseParser = new WienerBoerseParser(settingsWienerBoerse.urlWienerBoerse);
//var bonds = wienerBoerseParser.GetBonds();


//WienerBoerseParser getTables = new WienerBoerseParser();
//getTables.GetTables(
//    settingsWienerBoerse.urlWienerBoerse,
//    settingsWienerBoerse.IdContainer,
//    settingsWienerBoerse.tbody,
//    settingsWienerBoerse.tr,
//    settingsWienerBoerse.td,
//    settingsWienerBoerse.a,
//    settingsWienerBoerse.pathWienerBoerse
//    );