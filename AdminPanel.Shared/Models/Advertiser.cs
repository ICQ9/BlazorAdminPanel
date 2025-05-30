using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class Advertiser
    {
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("advertiserUrl")]
        public string AdvertiserUrl { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("profileFee")]
        public decimal ProfileFee { get; set; }

        [JsonPropertyName("isProfileFeePercent")]
        public bool IsProfileFeePercent { get; set; }

        [JsonPropertyName("inventoryFee")]
        public decimal InventoryFee { get; set; }

        [JsonPropertyName("isInventoryFeePercent")]
        public bool IsInventoryFeePercent { get; set; }

        [JsonPropertyName("dmpFee")]
        public decimal DmpFee { get; set; }

        [JsonPropertyName("isDmpFeePercent")]
        public bool IsDmpFeePercent { get; set; }

        [JsonPropertyName("creativeFee")]
        public decimal CreativeFee { get; set; }

        [JsonPropertyName("isCreativeFeePercent")]
        public bool IsCreativeFeePercent { get; set; }

        [JsonPropertyName("creditLimit")]
        public decimal CreditLimit { get; set; }

        [JsonPropertyName("isSpendLimited")]
        public bool IsSpendLimited { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("countryId")]
        public int CountryId { get; set; }

        [JsonPropertyName("tradeDeskId")]
        public int TradeDeskId { get; set; }

        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; } = new List<string>();

        [JsonPropertyName("brandName")]
        public string BrandName { get; set; }
    }
}

