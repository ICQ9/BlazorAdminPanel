using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class CreateUserModel
    {   
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("subscriptionOid")]
        public string SubscriptionOid { get; set; }

        [JsonPropertyName("subscriptionId")]
        public int SubscriptionId { get; set; }

        [JsonPropertyName("emailVerification")]
        public bool EmailVerification { get; set; }

        [JsonPropertyName("isTwoFactorAuthenticationEnabled")]
        public bool IsTwoFactorAuthenticationEnabled { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("isBookkeeper")]
        public bool IsBookkeeper { get; set; }

        [JsonPropertyName("subscriptionType")]
        public string SubscriptionType { get; set; }

        [JsonPropertyName("roleType")]
        public int RoleType { get; set; }

        [JsonPropertyName("tradedeskId")]
        public int TradeDeskId { get; set; }

        [JsonPropertyName("customAdvertisers")]
        public bool CustomAdvertisers { get; set; }

        [JsonPropertyName("newAdvertiserIsAvailable")]
        public int NewAdvertiserIsAvailable { get; set; }

        [JsonPropertyName("advertiserIds")]
        public List<int> AdvertiserIds { get; set; } = new List<int>();
    }
}
