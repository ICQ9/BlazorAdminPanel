using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class RecomendedPrice
    {
        public Filters Filters { get; set; }
    }

    public class Filters
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Currency { get; set; }
        public string TimeZone { get; set; }
        public Guid SubscriptionOId { get; set; }
        public int DspId { get; set; }
        public int MinViewability { get; set; }
        public int MaxViewability { get; set; }
        public decimal MinBidFloor { get; set; }
        public decimal MaxBidFloor { get; set; }

        public List<string> Geo { get; set; }
        public List<string> ExcludedGeo { get; set; }
        public List<string> Domains { get; set; }
        public List<string> ExcludedDomains { get; set; }
        public List<string> IncludedUrlGroups { get; set; }
        public List<string> ExcludedUrlGroups { get; set; }
        public List<string> AgeGroups { get; set; }
        public List<string> Genders { get; set; }
        public List<string> Environments { get; set; }
        public List<string> DeviceTypes { get; set; }
        public List<string> Os { get; set; }
        public List<string> ConnectionTypes { get; set; }
        public List<string> Carriers { get; set; }
        public List<string> Browsers { get; set; }
        public List<string> SspNames { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> CreativeTemplates { get; set; }
        public List<string> Segments { get; set; }

        public Dictionary<string, string> SegmentGroupOperators { get; set; }

        public List<string> Categories { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Sections { get; set; }
        public List<string> InventorySources { get; set; }
        public List<string> Publishers { get; set; }
        public List<string> GeoTypes { get; set; }
        public int ProductFormatId { get; set; }
    }
}
