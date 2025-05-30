using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class GeoLocation
    {
        public AvailableGeo Location { get; set; }
        public bool IsIncluded { get; set; }
    }
}
