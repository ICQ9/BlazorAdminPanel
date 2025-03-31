using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdminPanel.Shared.Models
{
    public class SaveProductModel
    {

        [Required(ErrorMessage = "Campaign name is required")]
        [StringLength(100, ErrorMessage = "Campaign name cannot exceed 100 characters")]
        [Display(Name = "Campaign Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campaign budget is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Budget must be greater than 0")]
        [Display(Name = "Campaign Budget")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Campaign type is required")]
        [Display(Name = "Campaign Type")]
        public ProductType Type { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

        [Required(ErrorMessage = "Advertiser ID is required")]
        [Display(Name = "Advertiser")]
        public string AdvertiserId { get; set; }

        [Display(Name = "Currency")]
        public string Currency { get; set; } = "USD";

        [Display(Name = "Time Zone")]
        public string TimeZone { get; set; } = "UTC";
        
        public string State { get; set; }

    public bool IsDateRangeValid()
        {
            return DateFrom < DateTo && DateFrom >= DateTime.Today;
        }

        /// <summary>
        /// Gets the validation error message for the date range if invalid
        /// </summary>
        /// <returns>Error message if invalid, null if valid</returns>
        public string GetDateRangeErrorMessage()
        {
            if (!IsDateRangeValid())
            {
                if (DateFrom >= DateTo)
                    return "End date must be after start date";
                if (DateFrom < DateTime.Today)
                    return "Start date cannot be in the past";
            }
            return null;
        }

        /// <summary>
        /// Gets the display name for the campaign type
        /// </summary>
        public string GetCampaignTypeDisplayName()
        {
            var memberInfo = Type.GetType().GetMember(Type.ToString());
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)[0] as DisplayAttribute;
            return displayAttribute?.Name ?? Type.ToString();
        }
    }

    public enum ProductType
    {

    }
}
