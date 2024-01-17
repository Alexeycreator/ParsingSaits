using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleAppParsing
{
    public class WriteToFile
    {
        public void Filing(string path, List<WienerBoerseHtml> elemWiener)
        {
            StringBuilder scv = new StringBuilder();
            for (int i = 0; i < elemWiener.Count; i++)
            {
                scv.AppendLine(elemWiener[i].Name + ";" + elemWiener[i].ISin + ";" + elemWiener[i].Status);
                File.AppendAllText(path, scv.ToString());
            }
        }
    }
}
