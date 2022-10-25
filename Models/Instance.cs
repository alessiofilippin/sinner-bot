using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SinnerBot.Models
{
    public class Instance
    {
        [JsonPropertyName("instance")]
        public InstanceDetails instance { get; set; }

        public Instance(InstanceDetails _instance)
        {
            instance = _instance;
        }
    }
}
