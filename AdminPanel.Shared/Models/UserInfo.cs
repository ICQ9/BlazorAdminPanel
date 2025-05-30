using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class UserInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("oid")]
        public Guid Oid { get; set; }

        [JsonPropertyName("networkCurrency")]
        public string NetworkCurrency { get; set; }

        [JsonPropertyName("networkTimeZone")]
        public string NetworkTimeZone { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("masterRoleType")]
        public string MasterRoleType { get; set; }

        [JsonPropertyName("permissions")]
        public List<string> Permissions { get; set; } = new List<string>();

        [JsonPropertyName("roleType")]
        public int RoleType { get; set; }

        [JsonPropertyName("subscriptionType")]
        public string SubscriptionType { get; set; }

        [JsonPropertyName("isAgencyTechStack")]
        public bool IsAgencyTechStack { get; set; }

        [JsonPropertyName("lcid")]
        public int Lcid { get; set; }

        [JsonPropertyName("availableSupport")]
        public string AvailableSupport { get; set; }

        [JsonPropertyName("objectSubscriptionId")]
        public int ObjectSubscriptionId { get; set; }

        [JsonPropertyName("subscriptionName")]
        public string SubscriptionName { get; set; }

        [JsonPropertyName("isDmpReseller")]
        public bool IsDmpReseller { get; set; }

        [JsonPropertyName("weekStart")]
        public int WeekStart { get; set; }

        [JsonPropertyName("defaultCommission")]
        public decimal DefaultCommission { get; set; }

        [JsonPropertyName("platformUIAvailable")]
        public bool PlatformUIAvailable { get; set; }

        [JsonPropertyName("isHbAvailable")]
        public bool IsHbAvailable { get; set; }
    }
}
