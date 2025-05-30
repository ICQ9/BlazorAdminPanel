using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class CpmData
    {
        [JsonPropertyName("percent")]
        public double Percent { get; set; }

        [JsonPropertyName("cpm")]
        public double Cpm { get; set; }
    }
}
