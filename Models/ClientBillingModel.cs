using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrmsWeb.Models
{
    public class ClientBillingModel
    {
        public int CBId { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int LocationId { get; set; }

        public int MaximumBillableDays { get; set; }
        public int BillingPeriodFrom { get; set; }
        public int BillingPeriodTo { get; set; }
        public int LeavesAllowedPerMonth { get; set; }
        public string PanNo { get; set; }
        public string GSTIN { get; set; }

        public Nullable<DateTime> ValidFrom { get; set; }
        public Nullable<DateTime> ValidTo { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> LastUpdatedDate { get; set; }

        public string UserName { get; set; }
        public string ProjectName { get; set; }
        public string LocationName { get; set; }
        public string ClientName { get; set; }

        public int srClientId { get; set; }


        public int ClientSetUpId { get; set; }
    }
}