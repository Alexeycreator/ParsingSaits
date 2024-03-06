using System.Runtime.Serialization;

namespace WebApplication5.Models
{
    [DataContract]
    public class OptionsModel
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "name")]
        public string FileName { get; set; }
        [DataMember(Name = "data_stream")]
        public string DataStream { get; set; }
    }
}
