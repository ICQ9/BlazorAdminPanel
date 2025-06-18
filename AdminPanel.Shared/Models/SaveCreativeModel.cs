using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class SaveCreativeModel
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string LandingPageType { get; set; }
        public string TrackingUrl { get; set; }
        public int AdvertiserId { get; set; }
        public string AdvertiserUrl { get; set; }
        public int TemplateId { get; set; }
        public string BrandName { get; set; }
        public List<string> Categories { get; set; }

        public SaveCreativeModel()
        {
            Categories = new List<string>();
        }
    }
}
