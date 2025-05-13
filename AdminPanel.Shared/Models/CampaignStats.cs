using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class CampaignStats
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("impressions")]
        public int Impressions { get; set; }

        [JsonPropertyName("viewableImpressions")]
        public int ViewableImpressions { get; set; }

        [JsonPropertyName("viewability")]
        public decimal Viewability { get; set; }

        [JsonPropertyName("clicks")]
        public int Clicks { get; set; }

        [JsonPropertyName("ctr")]
        public decimal Ctr { get; set; }

        [JsonPropertyName("viewableCTR")]
        public decimal ViewableCtr { get; set; }

        [JsonPropertyName("ecpm")]
        public decimal Ecpm { get; set; }

        [JsonPropertyName("evCPM")]
        public decimal EvCpm { get; set; }

        [JsonPropertyName("ecpc")]
        public decimal Ecpc { get; set; }

        [JsonPropertyName("inventoryCost")]
        public decimal InventoryCost { get; set; }

        [JsonPropertyName("dmpCost")]
        public decimal DmpCost { get; set; }

        [JsonPropertyName("creativeCost")]
        public decimal CreativeCost { get; set; }

        [JsonPropertyName("inventoryFee")]
        public decimal InventoryFee { get; set; }

        [JsonPropertyName("dmpFee")]
        public decimal DmpFee { get; set; }

        [JsonPropertyName("creativeFee")]
        public decimal CreativeFee { get; set; }

        [JsonPropertyName("totalInventoryCost")]
        public decimal TotalInventoryCost { get; set; }

        [JsonPropertyName("totalDMPCost")]
        public decimal TotalDmpCost { get; set; }

        [JsonPropertyName("totalCreativeCost")]
        public decimal TotalCreativeCost { get; set; }

        [JsonPropertyName("techFeeTradeDesk")]
        public decimal TechFeeTradeDesk { get; set; }

        [JsonPropertyName("inventoryFeeTradeDesk")]
        public decimal InventoryFeeTradeDesk { get; set; }

        [JsonPropertyName("dmpFeeTradeDesk")]
        public decimal DmpFeeTradeDesk { get; set; }

        [JsonPropertyName("creativeFeeTradeDesk")]
        public decimal CreativeFeeTradeDesk { get; set; }

        [JsonPropertyName("profileFeeTradeDesk")]
        public decimal ProfileFeeTradeDesk { get; set; }

        [JsonPropertyName("spend")]
        public decimal Spend { get; set; }

        [JsonPropertyName("profit")]
        public decimal Profit { get; set; }

        [JsonPropertyName("revenue")]
        public decimal Revenue { get; set; }

        [JsonPropertyName("profitTradeDesk")]
        public decimal ProfitTradeDesk { get; set; }

        [JsonPropertyName("revenueTradeDesk")]
        public decimal RevenueTradeDesk { get; set; }

        [JsonPropertyName("ecpcTradeDesk")]
        public decimal EcpcTradeDesk { get; set; }

        [JsonPropertyName("ecpmTradeDesk")]
        public decimal EcpmTradeDesk { get; set; }

        [JsonPropertyName("evCPMTradeDesk")]
        public decimal EvCpmTradeDesk { get; set; }
    }
}
