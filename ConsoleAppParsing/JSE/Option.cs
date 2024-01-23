using System;

namespace ConsoleAppParsing
{
    public class Option
    {
        public string CallPut { get; set; }
        public string FutureExpiry { get; set; }
        public string FuturesPrice { get; set; }
        public string Origin { get; set; }
        public string Premium { get; set; }
        public string Quantity { get; set; }
        public string ShortName { get; set; }
        public string Strike { get; set; }
        public string TradeDate { get; set; }
        public string TradeType { get; set; }
        public string Vol { get; set; }
    }
}