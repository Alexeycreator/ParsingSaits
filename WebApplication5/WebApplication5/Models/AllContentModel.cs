using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    [DataContract]
    public class AllContentModel
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "name")]
        public string FileName { get; set; }
        [DataMember(Name = "data_stream")]
        public string DataStream { get; set; }
    }
}
