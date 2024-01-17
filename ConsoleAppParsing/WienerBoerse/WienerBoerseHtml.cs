using System;

namespace ConsoleAppParsing
{
    public class WienerBoerseHtml
    {
        public string Name { get; set; }
        public double Last { get; set; }
        public double Chg { get; set; }
        public DateTime Date { get; set; }
        public string ISin { get; set; }
        public double BidVolume { get; set; }
        public double AskVolume { get; set; }
        public DateTime Maturity { get; set; }
        public string Status { get; set; }
    }
}