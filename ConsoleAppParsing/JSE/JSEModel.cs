using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppParsing.JSE
{
    class JSEModel
    {
        [JsonProperty(PropertyName = "GetTradeOptionsResult")]
        public List<Option> StateTablesJSE { get; set; }
    }
}
