using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SinnerBot.Models
{
    public class InstanceDetails
    {
        [JsonPropertyName("serverID")]
        public string serverID { get; set; }

        [JsonPropertyName("availableMajorArcana")]
        public List<int>[] availableMajorArcana { get; set; }

        [JsonPropertyName("availableMinorArcana")]
        public List<int>[] availableMinorArcana { get; set; }

        public InstanceDetails(string _serverID, List<int>[] _availableMajorArcana, List<int>[] _availableMinorArcana)
        {
            serverID = _serverID;
            availableMajorArcana = _availableMajorArcana;
            availableMinorArcana = _availableMinorArcana;
        }
    }
}
