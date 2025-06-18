using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class GeoLocalTargeting
    {
        public string TargetingType { get; set; } = "Local";
        public List<GeoLocation> IncludedLocations { get; set; } = new List<GeoLocation>();
    }
}
