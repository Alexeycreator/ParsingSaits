using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleAppParsing
{
    public class CsvWriter
    {
        public void Write(string pathFileCSV, List<Bond> bonds)
        {
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("cells1;cells2;");
            foreach(var bond in bonds)
            {
                csvBuilder.AppendLine($"{bond.Name}");
            }
            File.WriteAllText(pathFileCSV, csvBuilder.ToString());
        }
        public void Write(string pathFileCSV, List<Option> options)
        {
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Trade Date;Trade Type;Short Name;Future Expiry;Strike;Call/Put;Quantity;Vol;Premium;Futures Price");
            foreach (var option in options)
            {
                csvBuilder.AppendLine($"{option.TradeDate};{option.TradeType};{option.ShortName};{option.FutureExpiry};{option.Strike};{option.CallPut};{option.Quantity};{option.Vol};{option.Premium};{option.FuturesPrice}");
            }
            File.WriteAllText(pathFileCSV, csvBuilder.ToString());
        }
    }
}
