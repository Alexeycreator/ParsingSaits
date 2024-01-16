using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppParsing
{
    public class WienerBoerseHtml
    {
        public string urlWienerBoerse { get; set; } = "https://www.wienerborse.at/en/bonds/?c7928-page=2&per-page=50&cHash=ee36cc2f1ce3bd58128f6364139c8e3d";
        public int startPage { get; set; }
        public int endPage { get; set; }
        public string Name { get; set; }
        public double Last { get; set; }
        public double Chg { get; set; }
        public DateTime DateTime { get; set; }
        public string ISin { get; set; }
        public double BidVolume { get; set; }
        public double AskVolume { get; set; }
        public DateTime Maturity { get; set; }
        public string Status { get; set; }

    }
}
