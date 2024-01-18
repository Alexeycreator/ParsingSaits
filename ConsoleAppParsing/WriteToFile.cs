using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleAppParsing
{
    public class WriteToFile
    {
        public void Write(string path, List<Bond> bonds)
        {
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("cells1;cells2;");
            foreach(var bond in bonds)
            {
                csvBuilder.AppendLine($"{bond.Name}");
            }
            File.WriteAllText(path, csvBuilder.ToString());
        }
        public void Write(string path, List<JSEModelState> bonds)
        {
            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("cells1;cells2;");
            foreach (var bond in bonds)
            {
                //csvBuilder.AppendLine($"{bond.Name}");
            }
            File.WriteAllText(path, csvBuilder.ToString());
        }
        //public void Filing(string path, List<WienerBoerseHtml> elemWiener)
        //{
        //    StringBuilder scv = new StringBuilder();
        //    for (int i = 0; i < elemWiener.Count; i++)
        //    {
        //        scv.AppendLine(elemWiener[i].Name + ";" + elemWiener[i].ISin + ";" + elemWiener[i].Status);
        //    }
        //    File.WriteAllText(path, scv.ToString());
        //}
    }
}
