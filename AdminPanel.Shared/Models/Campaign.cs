using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Shared.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string State { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string DailyBudgetLimit { get; set; }

        public string OwnerId { get; set; }

        public string AdvertiserOid { get; set; }

        public string Currency { get; set; }

        public string TimeZone { get;set; }

    }
}
