using System;

namespace ConsoleAppParsing
{
    public class JSEWebsiteHtml
    {
        public DateTime TradeDate { get; set; }
        public string TradeType { get; set; }
        public string ShortName { get; set; }
        public string FutureExpiry { get; set; }
        public int Strike { get; set; }
        public string Call_Put { get; set; }
        public int Quantity { get; set; }
        public double Vol { get; set; }
        public int Premium { get; set; }
        public double Futures_Price { get; set; }
    }
}