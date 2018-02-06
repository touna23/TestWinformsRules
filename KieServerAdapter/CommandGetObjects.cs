using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KieServerAdapter
{
    public class CommandGetObjects : ICommand, ICommandOutIdentifier
    {
        [JsonProperty("out-identifier")]
        public string OutIdentifier { get; set; } = "objects";
        
        [JsonIgnore]
        public KieCommandTypeEnum CommandType { get; } = KieCommandTypeEnum.GetObjects;
    }
}
