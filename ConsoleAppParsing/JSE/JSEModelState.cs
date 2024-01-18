using System;

namespace ConsoleAppParsing
{
    public class JSEModelState
    {
        public string CallPut { get; set; }
        public string FutureExpiry { get; set; }
        public double FuturesPrice { get; set; }
        public string Origin { get; set; }
        public double Premium { get; set; }
        public int Quantity { get; set; }
        public string ShortName { get; set; }
        public int Strike { get; set; }
        public string TradeDate { get; set; }
        public string TradeType { get; set; }
        public double Vol { get; set; }
    }
}