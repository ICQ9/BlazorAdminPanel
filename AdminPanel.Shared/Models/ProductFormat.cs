using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AdminPanel.Shared.Models
{
    public class ProductFormat
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int FormatId { get; set; }
        public string FormatName { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string Currency { get; set; }
        public string PriceModel { get; set; }
        public string ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public List<string> AuctionTypes { get; set; }
        public TargetingRestriction TargetingRestriction { get; set; }
        public List<string> InventoryTypes { get; set; }
        public int Superiority { get; set; }
        public bool ProfileValidationIsRequired { get; set; }
        public int InventoryTypeDMP { get; set; }
        public int AvailableBidder { get; set; }
        public int Order { get; set; }
    }

    public class TargetingRestriction
    {
        public bool RetargetingTargeting { get; set; }
        public bool URLTargeting { get; set; }
        public bool GeoTargeting { get; set; }
        public bool IPTargeting { get; set; }
        public bool DeviceTargeting { get; set; }
        public bool PlatformTargeting { get; set; }
        public bool EnvironmentTargeting { get; set; }
        public bool BrowserTargeting { get; set; }
        public bool SRTargenting { get; set; }
        public bool TimeTargeting { get; set; }
        public bool CategoryTargeting { get; set; }
        public bool IspTargeting { get; set; }
        public bool ViewAbilityTargeting { get; set; }
        public bool DealTargeting { get; set; }
        public bool ZoneTargeting { get; set; }
        public bool KeyValueTargeting { get; set; }
    }

    public class ProductFormatResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int FormatId { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string PriceModel { get; set; }
        public string ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public List<string> AuctionTypes { get; set; }
        public List<string> InventoryTypes { get; set; }
        public int Superiority { get; set; }
        public bool ProfileValidationIsRequired { get; set; }
        public int InventoryTypeDMP { get; set; }
        public int AvailableBidder { get; set; }
        public List<ProductFormat> FormatList { get; set; }
        public int Order { get; set; }
    }
} 