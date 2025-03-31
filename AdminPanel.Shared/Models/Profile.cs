using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public string FormatType { get; set; }

        public string ProductEnvironmentType { get; set; }

        public int TradeDeskId { get; set; }

        public int AdvertiserId { get; set; }

        public Guid AdvertiserOId { get; set; }

        public string AdvertiserName { get; set; }

        public int ProductFormatId { get; set; }

        public int ProductId { get; set; }

        public int FormatId { get; set; }

        public int CampaignId { get; set; }

        public string CampaignName { get; set; }

        public string State { get; set; }

        public string Currency { get; set; }

        public string TimeZone { get; set; }

        public string InterfaceType { get; set; }

        [JsonIgnore]
        public bool IsProfileValidated { get; set; }

        public bool ProfileValidationIsRequired { get; set; }

        public string ProductName { get; set; }

        public string FormatName { get; set; }

        public string TradeDeskName { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public bool CanModifyState { get; set; }

        public string EventsPlan { get; set; }

    }
}
