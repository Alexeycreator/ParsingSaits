using System;

namespace ConsoleAppParsing
{
    public class WienerBoerseHtml
    {
        public string Name { get ; set; }
        public double Last { get; set; }
        public string Chg { get; set; }
        public DateTime Date { get; set; }
        public string ISin { get; set; }
        public string TurnoverVolume { get; set; }
        public string BidVolume { get; set; }
        public string AskVolume { get; set; }
        public DateTime Maturity { get; set; }
        public string Status { get; set; }
    }
}