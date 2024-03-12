using System.Runtime.Serialization;

namespace WebApplication5.Models
{
    [DataContract]
    public class AllContentModel
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "name")]
        public string FileName { get; set; }
    }
}
