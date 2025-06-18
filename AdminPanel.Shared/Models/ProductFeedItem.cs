using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class ProductFeedItem
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageLinkJson { get; set; }
        public string Brand { get; set; }
        public string GoogleProductCategory { get; set; }
        public int TeaserFeedId { get; set; }
        public string Preview { get; set; }
        public string CategoryName { get; set; }
    }
}
