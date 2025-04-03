using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class ProductFeed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int ClientId { get; set; }
        public Guid AdvertiserOId { get; set; }
        public int AdvertiserId { get; set; }
        public string Settings { get; set; }
        public int TradeDeskId { get; set; }
        public string Currency { get; set; }
        public string TimeZone { get; set; }
        public int ItemsCount { get; set; }
    }
}
