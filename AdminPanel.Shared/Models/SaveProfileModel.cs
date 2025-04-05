using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class SaveProfileModel
    {

        [Required(ErrorMessage = "Campaign name is required")]
        [StringLength(100, ErrorMessage = "Campaign name cannot exceed 100 characters")]
        [Display(Name = "Campaign Name")]
        public string Name { get; set; }

        [Display(Name = "Campaign Budget")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? DateFrom { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? DateTo { get; set; }

        [Display(Name = "Currency")]
        public string Currency { get; set; } = "USD";

        [Display(Name = "Time Zone")]
        public string TimeZone { get; set; } = "UTC";

        public string State { get; set; }

        public int CampaignId { get; set; }
        public string Description { get; set; }
        public int ProductFormatId { get; set; }
        public string AdSourceType { get; set; }
        public decimal EventPrice { get; set; }
        public long ImpressionsLimit { get; set; }
        public int MaxEventsPerVisitor { get; set; }
        public int MaxEventsPeriod { get; set; }
        public string DeliveryDistribution { get; set; } = "EvenlyPerDay";
        public string BudgetRestrictionType { get; set; } = "Unlim";
        public string ImpressionsRestrictionType { get; set; } = "Profile";
        public string AuctionType { get; set; }
        public bool BlockPrebid { get; set; }
        public decimal BudgetLimit { get; set; }
        public bool NotShowAfterFirstClick { get; set; }
        public byte MaxEventsPerVisitorPerMinute { get; set; }
        public short MaxEventsPerVisitorMinutes { get; set; }
        public decimal VIModelTargetRate { get; set; }
        public string DealIds { get; set; }
        public int Superiority { get; set; }
        public bool IsProfileValidated { get; set; }
        public bool IsDMPProfilingAvailable { get; set; }
        public bool ShowWatermark { get; set; }
        public bool IsTeaserProfile { get; set; }
        public bool IsDmpContainerEnabled { get; set; }
    

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
        /*public string GetProfileTypeDisplayName()
        {
            var memberInfo = Type.GetType().GetMember(Type.ToString());
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)[0] as DisplayAttribute;
            return displayAttribute?.Name ?? Type.ToString();
        }*/
    }
}
